#pragma once
#include "TeamsForm.h"
#include "PoolsForm.h"
#include "TournamentForm.h"
#include "MatchHistoryForm.h"
#include "Scheduler.h"
#include <queue>

using namespace std; 

namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;

    public ref class MyForm : public Form {
    private:
        Button^ viewTeamsButton; // Button to view the Teams Overview screen
        Button^ viewPoolsButton; // Button to view the Pools Overview screen
        Button^ tournamentButton; // Button to view the Tournament Progress screen
        Button^ matchHistoryButton; // Button to view the Match History screen

        Scheduler* scheduler; // Pointer to the Scheduler object for managing tournament data
        Panel^ childPanel; // Panel for displaying child forms dynamically

    public:
        // Constructor to initialize the main form and its components
        MyForm() {
            // Main Form Settings
            this->Text = "SHOWDOWN SCHEDULER"; // Title of the application
            this->Size = Drawing::Size(800, 600); // Dimensions of the form
            this->BackColor = Color::Black; // Background color of the form

            // Header Label
            Label^ heading = gcnew Label();
            heading->Text = "SHOWDOWN SCHEDULER"; // Title displayed on the form
            heading->ForeColor = Color::White; // Text color
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold); // Font settings
            heading->Size = Drawing::Size(400, 40); // Size of the label
            heading->Location = Point(200, 10); // Position of the label
            heading->TextAlign = ContentAlignment::MiddleCenter; // Center alignment
            this->Controls->Add(heading);

            // View Teams Button
            viewTeamsButton = gcnew Button();
            viewTeamsButton->Text = "View Teams"; // Button text
            viewTeamsButton->Location = Point(50, 80); // Position on the form
            viewTeamsButton->Size = Drawing::Size(150, 40); // Button size
            viewTeamsButton->BackColor = Color::Blue; // Background color
            viewTeamsButton->ForeColor = Color::White; // Text color
            viewTeamsButton->Click += gcnew EventHandler(this, &MyForm::OnViewTeams); // Event handler
            this->Controls->Add(viewTeamsButton);

            // View Pools Button
            viewPoolsButton = gcnew Button();
            viewPoolsButton->Text = "View Pools"; // Button text
            viewPoolsButton->Location = Point(250, 80); // Position on the form
            viewPoolsButton->Size = Drawing::Size(150, 40); // Button size
            viewPoolsButton->BackColor = Color::Blue; // Background color
            viewPoolsButton->ForeColor = Color::White; // Text color
            viewPoolsButton->Click += gcnew EventHandler(this, &MyForm::OnViewPools); // Event handler
            this->Controls->Add(viewPoolsButton);

            // Tournament Button
            tournamentButton = gcnew Button();
            tournamentButton->Text = "Tournament"; // Button text
            tournamentButton->Location = Point(450, 80); // Position on the form
            tournamentButton->Size = Drawing::Size(150, 40); // Button size
            tournamentButton->BackColor = Color::Blue; // Background color
            tournamentButton->ForeColor = Color::White; // Text color
            tournamentButton->Click += gcnew EventHandler(this, &MyForm::OnTournament); // Event handler
            this->Controls->Add(tournamentButton);

            // Match History Button
            matchHistoryButton = gcnew Button();
            matchHistoryButton->Text = "Match History"; // Button text
            matchHistoryButton->Location = Point(650, 80); // Position on the form
            matchHistoryButton->Size = Drawing::Size(150, 40); // Button size
            matchHistoryButton->BackColor = Color::Green; // Background color
            matchHistoryButton->ForeColor = Color::White; // Text color
            matchHistoryButton->Click += gcnew EventHandler(this, &MyForm::OnMatchHistory); // Event handler
            this->Controls->Add(matchHistoryButton);

            // Panel for Child Forms
            childPanel = gcnew Panel();
            childPanel->Location = Point(0, 0); // Position of the panel
            childPanel->Size = Drawing::Size(800, 600); // Size of the panel
            childPanel->BackColor = Color::Black; // Background color
            childPanel->Visible = false; // Initially hidden
            this->Controls->Add(childPanel);

            // Initialize Scheduler
            scheduler = new Scheduler();
            scheduler->loadTeams("teams.txt"); // Load team data
            scheduler->dividePools(); // Divide teams into pools
        }

        // Destructor to clean up resources
        ~MyForm() {
            delete scheduler; // Delete scheduler to free memory
        }

    private:
        // Function to open child forms inside the panel
        void OpenChildForm(Form^ childForm) {
            ToggleMainScreen(false); // Hide main screen components

            // Clear the panel and add the child form
            childPanel->Controls->Clear();
            childForm->TopLevel = false; // Set as non-top-level form
            childForm->Dock = DockStyle::Fill; // Fill the panel
            childForm->FormBorderStyle = System::Windows::Forms::FormBorderStyle::None; // Remove borders
            childPanel->Controls->Add(childForm);

            // Add Back Button to Panel
            Button^ backButton = gcnew Button();
            backButton->Text = "Back"; // Button text
            backButton->Location = Point(10, 10); // Position
            backButton->Size = Drawing::Size(100, 40); // Button size
            backButton->BackColor = Color::Red; // Background color
            backButton->ForeColor = Color::White; // Text color
            backButton->Click += gcnew EventHandler(this, &MyForm::OnBackButton); // Event handler
            childPanel->Controls->Add(backButton);

            childPanel->Visible = true; // Show the panel
            childForm->Show(); // Show the child form
        }

        // Function to toggle visibility of main screen components
        void ToggleMainScreen(bool visible) {
            for each (Control ^ control in this->Controls) {
                if (control != childPanel) {
                    control->Visible = visible; // Toggle visibility
                }
            }
        }

        // Event handler for Back Button
        void OnBackButton(Object^ sender, EventArgs^ e) {
            childPanel->Controls->Clear(); // Clear panel content
            childPanel->Visible = false; // Hide the panel
            ToggleMainScreen(true); // Show main screen components
        }

        // Event handler for "View Teams" button
        void OnViewTeams(Object^ sender, EventArgs^ e) {
            TeamsForm^ teamsForm = gcnew TeamsForm(scheduler->getTeams(), 16); // Open TeamsForm
            OpenChildForm(teamsForm);
        }

        // Event handler for "View Pools" button
        void OnViewPools(Object^ sender, EventArgs^ e) {
            PoolsForm^ poolsForm = gcnew PoolsForm(scheduler->getPoolAlpha(), scheduler->getPoolBeta()); // Open PoolsForm
            OpenChildForm(poolsForm);
        }

        // Event handler for "Tournament" button
        void OnTournament(Object^ sender, EventArgs^ e) {
            TournamentForm^ tournamentForm = gcnew TournamentForm(scheduler); // Open TournamentForm
            OpenChildForm(tournamentForm);
        }

        // Event handler for "Match History" button
        void OnMatchHistory(Object^ sender, EventArgs^ e) {
            queue<Match> matches = scheduler->getMatchHistory(); // Retrieve match history
            int matchCount = matches.size(); // Get match count

            // Convert queue to array for passing
            Match* matchArray = new Match[matchCount];
            for (int i = 0; i < matchCount; i++) {
                matchArray[i] = matches.front(); // Transfer match to array
                matches.pop(); // Remove match from queue
            }

            MatchHistoryForm^ matchHistoryForm = gcnew MatchHistoryForm(matchArray, matchCount); // Open MatchHistoryForm
            OpenChildForm(matchHistoryForm);
        }
    };
}
