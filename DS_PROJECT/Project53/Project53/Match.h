#ifndef MATCH_H
#define MATCH_H

#include "Team.h"
#include <string>
#include <ctime>

using namespace std; 

// Match class to represent a single match in the tournament
class Match {
public:
    Team* team1;          // Pointer to the first team in the match
    Team* team2;          // Pointer to the second team in the match
    string dateTime;      // Date and time when the match is scheduled
    string status;        // Status of the match (e.g., "Scheduled" or "Completed")
    Team* winner;         // Pointer to the team that won the match

    // Default constructor
    // Initializes the teams, status, and automatically sets the current date and time
    Match() : team1(nullptr), team2(nullptr), winner(nullptr), status("Scheduled") {
        char buffer[26]; // Buffer to hold the formatted date and time
        time_t now = time(0); // Get the current time
        ctime_s(buffer, sizeof(buffer), &now); // Format the time safely
        dateTime = string(buffer); // Store the formatted time as a string
    }

    // Parameterized constructor
    // Initializes the teams involved in the match, status, and sets the current date and time
    Match(Team* t1, Team* t2) : team1(t1), team2(t2), winner(nullptr), status("Scheduled") {
        char buffer[26]; // Buffer to hold the formatted date and time
        time_t now = time(0); // Get the current time
        ctime_s(buffer, sizeof(buffer), &now); // Format the time safely
        dateTime = string(buffer); // Store the formatted time as a string
    }
};

#endif // MATCH_H
