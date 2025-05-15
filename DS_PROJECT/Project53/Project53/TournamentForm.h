#pragma once
#include "Scheduler.h"

using namespace std; 
namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;

    public ref class TournamentForm : public Form {
    private:
        Button^ simulateButton;       // Button to simulate the current round
        Button^ backButton;           // Button to navigate back to the previous screen
        ListBox^ resultsBox;          // ListBox to display match results
        RadioButton^ manualModeButton; // RadioButton for manual mode
        RadioButton^ automaticModeButton; // RadioButton for automatic mode
        ProgressBar^ matchProgressBar; // Progress bar to visualize match simulation progress
        Scheduler* scheduler;         // Pointer to the Scheduler instance
        int round;                    // Current round of the tournament
        bool isManualMode;            // Flag to track manual or automatic mode

    public:
        TournamentForm(Scheduler* sched) : scheduler(sched), round(1), isManualMode(false) {
            // Form Properties
            this->Text = "Tournament Progress";
            this->Size = Drawing::Size(800, 600);
            this->BackColor = Color::Black;

            // Heading Label
            Label^ heading = gcnew Label();
            heading->Text = "TOURNAMENT PROGRESS";
            heading->ForeColor = Color::White;
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold);
            heading->Size = Drawing::Size(400, 40);
            heading->Location = Point(200, 20);
            heading->TextAlign = ContentAlignment::MiddleCenter;
            this->Controls->Add(heading);

            // Results Box
            resultsBox = gcnew ListBox();
            resultsBox->Location = Point(50, 100);
            resultsBox->Size = Drawing::Size(700, 300);
            resultsBox->BackColor = Color::Black;
            resultsBox->ForeColor = Color::White;
            this->Controls->Add(resultsBox);

            // Simulate Button
            simulateButton = gcnew Button();
            simulateButton->Text = "Simulate Round";
            simulateButton->Location = Point(200, 450);
            simulateButton->Size = Drawing::Size(120, 40);
            simulateButton->BackColor = Color::Green;
            simulateButton->ForeColor = Color::White;
            simulateButton->Click += gcnew EventHandler(this, &TournamentForm::OnSimulate);
            this->Controls->Add(simulateButton);

            // Back Button
            backButton = gcnew Button();
            backButton->Text = "Back";
            backButton->Location = Point(500, 450);
            backButton->Size = Drawing::Size(120, 40);
            backButton->BackColor = Color::Red;
            backButton->ForeColor = Color::White;
            backButton->Click += gcnew EventHandler(this, &TournamentForm::OnBack);
            this->Controls->Add(backButton);

            // Manual Mode Radio Button
            manualModeButton = gcnew RadioButton();
            manualModeButton->Text = "Manual Mode";
            manualModeButton->Location = Point(50, 420);
            manualModeButton->Size = Drawing::Size(120, 20);
            manualModeButton->ForeColor = Color::White;
            manualModeButton->CheckedChanged += gcnew EventHandler(this, &TournamentForm::OnModeChanged);
            this->Controls->Add(manualModeButton);

            // Automatic Mode Radio Button
            automaticModeButton = gcnew RadioButton();
            automaticModeButton->Text = "Automatic Mode";
            automaticModeButton->Location = Point(200, 420);
            automaticModeButton->Size = Drawing::Size(120, 20);
            automaticModeButton->ForeColor = Color::White;
            automaticModeButton->Checked = true; // Default mode is Automatic
            automaticModeButton->CheckedChanged += gcnew EventHandler(this, &TournamentForm::OnModeChanged);
            this->Controls->Add(automaticModeButton);

            // Match Progress Bar
            matchProgressBar = gcnew ProgressBar();
            matchProgressBar->Location = Point(50, 410);
            matchProgressBar->Size = Drawing::Size(700, 10);
            matchProgressBar->Visible = false; // Initially hidden
            this->Controls->Add(matchProgressBar);
        }

        // Event handler for Simulate Button
        void OnSimulate(Object^ sender, EventArgs^ e) {
            resultsBox->Items->Clear();
            matchProgressBar->Visible = true;
            matchProgressBar->Value = 0;

            try {
                Match* matches;

                // Determine the current round and simulate matches accordingly
                if (round == 1) { // Knockout Round
                    matches = scheduler->scheduleRound(8, round);
                    SimulateMatches(matches, 8, "Knockout Round");
                }
                else if (round == 2) { // Quarter-Finals
                    matches = scheduler->scheduleRound(4, round);
                    SimulateMatches(matches, 4, "Quarter-Finals");
                }
                else if (round == 3) { // Semi-Finals
                    matches = scheduler->scheduleRound(2, round);
                    SimulateMatches(matches, 2, "Semi-Finals");
                }
                else if (round == 4) { // Final
                    matches = scheduler->scheduleRound(1, round);
                    DisplayMatchDetails(matches[0], "Final");
                    resultsBox->Items->Add("CHAMPION OF SHOWDOWN: " + gcnew String(matches[0].winner->name.c_str()));
                    simulateButton->Enabled = false; // Disable further simulation
                }
                else {
                    resultsBox->Items->Add("Tournament Already Completed!");
                }
                round++;
            }
            catch (const std::runtime_error& e) {
                MessageBox::Show(gcnew String(e.what()), "Error", MessageBoxButtons::OK, MessageBoxIcon::Error);
            }

            matchProgressBar->Visible = false; // Hide progress bar after simulation
        }

        // Event handler for Back Button
        void OnBack(Object^ sender, EventArgs^ e) {
            this->Close();
        }

        // Event handler for Radio Buttons to switch modes
        void OnModeChanged(Object^ sender, EventArgs^ e) {
            isManualMode = manualModeButton->Checked;
            scheduler->setManualMode(isManualMode);
        }

    private:
        // Simulate matches for the current round
        void SimulateMatches(Match* matches, int count, String^ roundName) {
            resultsBox->Items->Add("Results for Round: " + roundName);

            for (int i = 0; i < count; i++) {
                // Update progress bar
                matchProgressBar->Value = ((i + 1) * 100) / count;
                System::Threading::Thread::Sleep(200); // Simulate delay for match processing

                // Manual mode: Prompt user to select the winner
                if (isManualMode) {
                    String^ message = "Select winner for match:\n" +
                        gcnew String(matches[i].team1->name.c_str()) + " vs " +
                        gcnew String(matches[i].team2->name.c_str());

                    System::Windows::Forms::DialogResult result = MessageBox::Show(
                        message,
                        "Manual Winner Selection",
                        MessageBoxButtons::YesNo,
                        MessageBoxIcon::Question
                    );

                    matches[i].winner = (result == System::Windows::Forms::DialogResult::Yes)
                        ? matches[i].team1
                        : matches[i].team2;
                }

                // Check for upset and update match status
                if (matches[i].status == "Upset") {
                    resultsBox->Items->Add("Upset: " + gcnew String(matches[i].team2->name.c_str()) +
                        " defeated " + gcnew String(matches[i].team1->name.c_str()));
                }

                matches[i].status = "Completed";
                DisplayMatchDetails(matches[i], roundName);
            }
        }

        // Display match details in the results box
        void DisplayMatchDetails(const Match& match, String^ roundName) {
            resultsBox->Items->Add(gcnew String(match.team1->name.c_str()) + " vs " +
                gcnew String(match.team2->name.c_str()) + " - Winner: " +
                gcnew String(match.winner->name.c_str()));
        }
    };
}
