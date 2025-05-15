#ifndef SCHEDULER_H
#define SCHEDULER_H

#include "Team.h"
#include "Match.h"
#include "Node.h"
#include <queue>
#include <fstream>
#include <stdexcept>
#include <string>
#include <cstring>
#include <cstdlib>
#include <ctime>

using namespace std;

class Scheduler {
private:
    Team teams[16];                // Array to store details of 16 teams
    queue<Team*> poolAlpha;        // Queue for Pool Alpha (Ranks 1–8)
    queue<Team*> poolBeta;         // Queue for Pool Beta (Ranks 9–16)
    queue<Team*> remainingTeams;   // Queue for teams advancing to the next rounds
    queue<Match> matchHistory;     // Queue to store completed matches
    Node* tournamentTreeRoot;      // Root node for the tournament's binary tree
    bool manualMode;               // Flag for manual or automatic match mode
    bool progressSaved;            // Indicates if the tournament progress is saved
    bool isPoolsInitialized;       // Indicates if the pools are initialized
    bool isTournamentCompleted;    // Indicates if the tournament is completed
    Team* originalTeams[16];       // Array to preserve the original team data

public:
    // Constructor
    Scheduler() : tournamentTreeRoot(nullptr), manualMode(false), progressSaved(false), isPoolsInitialized(false), isTournamentCompleted(true) {
        srand(static_cast<unsigned int>(time(0))); // Seed randomness for match outcomes
        for (int i = 0; i < 16; ++i) {
            originalTeams[i] = nullptr; // Initialize pointers to null
        }
    }

    // Destructor
    ~Scheduler() {
        deleteTournamentTree(tournamentTreeRoot); // Clean up the binary tree
    }

    // Set the manual or automatic mode for match simulation
    void setManualMode(bool manual) {
        manualMode = manual;
    }

    // Load teams from a file with error handling
    void loadTeams(const string& filename) {
        ifstream file(filename);
        if (!file.is_open()) {
            throw runtime_error("Unable to open file: " + filename);
        }

        string line;
        int index = 0;

        // Read each line from the file and parse team data
        while (getline(file, line) && index < 16) {
            parseTeamData(line, index);
            originalTeams[index] = &teams[index];
            index++;
        }

        if (index != 16) { // Ensure exactly 16 teams are loaded
            throw runtime_error("File must contain exactly 16 teams.");
        }

        file.close();
        dividePools();           // Divide teams into Pool Alpha and Pool Beta
        isPoolsInitialized = true;
        isTournamentCompleted = false;
    }

    // Divide teams into Pool Alpha and Pool Beta based on their ranks
    void dividePools() {
        clearPools(); // Clear existing pools if any

        Team* tempArray[16];
        for (int i = 0; i < 16; ++i) {
            tempArray[i] = originalTeams[i];
        }

        // Bubble sort to rank teams by their rank attribute
        for (int i = 0; i < 16 - 1; ++i) {
            for (int j = 0; j < 16 - i - 1; ++j) {
                if (tempArray[j]->rank > tempArray[j + 1]->rank) {
                    Team* temp = tempArray[j];
                    tempArray[j] = tempArray[j + 1];
                    tempArray[j + 1] = temp;
                }
            }
        }

        // Divide sorted teams into Pool Alpha (Ranks 1–8) and Pool Beta (Ranks 9–16)
        for (int i = 0; i < 16; ++i) {
            if (tempArray[i]->rank <= 8) {
                poolAlpha.push(tempArray[i]);
            }
            else {
                poolBeta.push(tempArray[i]);
            }
        }
    }

    // Schedule matches for the current round
    Match* scheduleRound(int matchCount, int round) {
        static Match matches[8]; // Array to hold matches for the round

        if (round == 1) { // First round (Knockout round)
            if (poolAlpha.size() < 8 || poolBeta.size() < 8) {
                throw runtime_error("Not enough teams in pools for Round 1.");
            }
            for (int i = 0; i < matchCount; ++i) {
                Team* team1 = poolAlpha.front();
                poolAlpha.pop();
                Team* team2 = poolBeta.front();
                poolBeta.pop();

                matches[i] = Match(team1, team2);
                matches[i].winner = (rand() % 2 == 0) ? team1 : team2; // Random winner

                string matchInfo = string(team1->name) + " vs " + string(team2->name) + " - Winner: " + string(matches[i].winner->name);
                if (matches[i].winner == team2) { // Upset case
                    matchInfo += " (Upset)";
                }

                matches[i].status = matchInfo; // Store match details
                remainingTeams.push(matches[i].winner); // Push winner to remaining teams
                matchHistory.push(matches[i]); // Add match to history
            }
        }
        else { // Subsequent rounds
            if (remainingTeams.size() < 2 * matchCount) {
                throw runtime_error("Not enough teams to schedule matches.");
            }
            for (int i = 0; i < matchCount; ++i) {
                Team* team1 = remainingTeams.front();
                remainingTeams.pop();
                Team* team2 = remainingTeams.front();
                remainingTeams.pop();

                matches[i] = Match(team1, team2);
                matches[i].winner = (rand() % 2 == 0) ? team1 : team2; // Random winner
                matches[i].status = string(team1->name) + " vs " + string(team2->name) + " - Winner: " + string(matches[i].winner->name);

                remainingTeams.push(matches[i].winner); // Push winner to next round
                matchHistory.push(matches[i]); // Add match to history
            }
        }

        if (round == 4) { // Final round
            isTournamentCompleted = true;
        }

        return matches;
    }

    // Reset the tournament
    void resetTournament() {
        if (!isTournamentCompleted) {
            throw runtime_error("Cannot reset while a tournament is ongoing. Complete the current tournament first.");
        }

        clearPools();
        while (!remainingTeams.empty()) remainingTeams.pop();
        while (!matchHistory.empty()) matchHistory.pop();
        dividePools();
        isTournamentCompleted = false;
    }

    // Getters for Pool Alpha
    queue<Team*> getPoolAlpha() const {
        if (!isPoolsInitialized) {
            throw runtime_error("Pools are not initialized. Load teams first.");
        }
        return poolAlpha;
    }

    // Getters for Pool Beta
    queue<Team*> getPoolBeta() const {
        if (!isPoolsInitialized) {
            throw runtime_error("Pools are not initialized. Load teams first.");
        }
        return poolBeta;
    }

    // Get match history
    queue<Match> getMatchHistory() const {
        return matchHistory;
    }

    // Get all teams
    Team* getTeams() const {
        return const_cast<Team*>(teams);
    }

private:
    // Parse team data from a CSV line
    void parseTeamData(const string& line, int index) {
        char buffer[1024] = { 0 };
        strncpy_s(buffer, sizeof(buffer), line.c_str(), _TRUNCATE);

        char* context = nullptr;
        char* token = strtok_s(buffer, ",", &context);
        teams[index].name = token;

        token = strtok_s(nullptr, ",", &context);
        teams[index].leadName = token ? token : "";

        token = strtok_s(nullptr, ",", &context);
        teams[index].leadGender = token ? token : "";

        token = strtok_s(nullptr, ",", &context);
        teams[index].leadContact = token ? token : "";

        token = strtok_s(nullptr, ",", &context);
        teams[index].leadEmail = token ? token : "";

        for (int i = 0; i < 2; ++i) {
            token = strtok_s(nullptr, ",", &context);
            teams[index].members[i].name = token ? token : "";

            token = strtok_s(nullptr, ",", &context);
            teams[index].members[i].gender = token ? token : "";

            token = strtok_s(nullptr, ",", &context);
            teams[index].members[i].contact = token ? token : "";

            token = strtok_s(nullptr, ",", &context);
            teams[index].members[i].email = token ? token : "";
        }

        token = strtok_s(nullptr, ",", &context);
        teams[index].rank = stoi(token);
    }

    // Clear both pools
    void clearPools() {
        while (!poolAlpha.empty()) poolAlpha.pop();
        while (!poolBeta.empty()) poolBeta.pop();
    }

    // Delete the binary tree nodes recursively
    void deleteTournamentTree(Node* root) {
        if (!root) return;
        deleteTournamentTree(root->left);
        deleteTournamentTree(root->right);
        delete root;
    }
};

#endif
