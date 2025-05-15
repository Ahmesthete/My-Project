#pragma once
#include "TeamDetailsForm.h"
#include "Team.h"

namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;
    using namespace std; // Added for using STL string and related functionalities

    // TeamsForm: Displays the list of teams and their details
    public ref class TeamsForm : public Form {
    private:
        ListView^ teamsListView; // ListView for displaying team data
        Button^ backButton;      // Button to return to the previous screen
        TextBox^ searchBox;      // Search bar for filtering teams
        Label^ searchLabel;      // Label for the search bar
        Team* teams;             // Array of teams
        int teamCount;           // Total number of teams

    public:
        // Constructor: Initializes the form and loads team data
        TeamsForm(Team* teamsArray, int count) : teams(teamsArray), teamCount(count) {
            // Form Settings
            this->Text = "Teams Overview"; // Title of the form
            this->Size = Drawing::Size(800, 600); // Form size
            this->BackColor = Color::Black; // Background color

            // Header Label
            Label^ heading = gcnew Label();
            heading->Text = "TEAMS OVERVIEW";
            heading->ForeColor = Color::White;
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold);
            heading->Size = Drawing::Size(400, 40);
            heading->Location = Point(200, 20);
            heading->TextAlign = ContentAlignment::MiddleCenter;
            this->Controls->Add(heading);

            // Search Bar Label
            searchLabel = gcnew Label();
            searchLabel->Text = "Search by Name or Rank:";
            searchLabel->ForeColor = Color::White;
            searchLabel->Font = gcnew Drawing::Font("Arial", 12);
            searchLabel->Size = Drawing::Size(200, 20);
            searchLabel->Location = Point(100, 70);
            this->Controls->Add(searchLabel);

            // Search Box
            searchBox = gcnew TextBox();
            searchBox->Location = Point(300, 70);
            searchBox->Size = Drawing::Size(200, 25);
            searchBox->TextChanged += gcnew EventHandler(this, &TeamsForm::OnSearch);
            this->Controls->Add(searchBox);

            // ListView for displaying team data
            teamsListView = gcnew ListView();
            teamsListView->View = View::Details; // Display as details
            teamsListView->FullRowSelect = true; // Enable full-row selection
            teamsListView->Size = Drawing::Size(600, 350);
            teamsListView->Location = Point(100, 110);
            teamsListView->BackColor = Color::Black;
            teamsListView->ForeColor = Color::White;

            // Add columns to ListView
            teamsListView->Columns->Add("Team Name", 200); // Team Name column
            teamsListView->Columns->Add("Lead Name", 200); // Lead Name column
            teamsListView->Columns->Add("Rank", 100);      // Rank column

            // Load initial team data into ListView
            LoadTeamsData();

            // Event handler for activating a team item
            teamsListView->ItemActivate += gcnew EventHandler(this, &TeamsForm::OnTeamSelected);
            this->Controls->Add(teamsListView);

            // Back Button
            backButton = gcnew Button();
            backButton->Text = "Back";
            backButton->Location = Point(350, 500);
            backButton->Size = Drawing::Size(100, 40);
            backButton->BackColor = Color::Red;
            backButton->ForeColor = Color::White;
            backButton->Click += gcnew EventHandler(this, &TeamsForm::OnBack);
            this->Controls->Add(backButton);
        }

        // LoadTeamsData: Loads and displays team data in the ListView
        void LoadTeamsData() {
            teamsListView->Items->Clear(); // Clear existing items in ListView

            // Sort teams by rank using a nested loop
            for (int i = 0; i < teamCount - 1; i++) {
                for (int j = i + 1; j < teamCount; j++) {
                    if (teams[i].rank > teams[j].rank) {
                        Team temp = teams[i];
                        teams[i] = teams[j];
                        teams[j] = temp;
                    }
                }
            }

            // Add sorted team data to ListView
            for (int i = 0; i < teamCount; i++) {
                String^ teamName = gcnew String(teams[i].name.c_str()); // Convert team name to managed string
                String^ rank = teams[i].rank.ToString();               // Convert rank to string

                ListViewItem^ item = gcnew ListViewItem(teamName);     // Create a ListViewItem
                item->SubItems->Add(gcnew String(teams[i].leadName.c_str())); // Add lead name as a subitem
                item->SubItems->Add(rank);                             // Add rank as a subitem
                teamsListView->Items->Add(item);                       // Add item to ListView
            }
        }

        // OnSearch: Filters teams in the ListView based on search input
        void OnSearch(Object^ sender, EventArgs^ e) {
            String^ searchText = searchBox->Text->ToLower(); // Convert search text to lowercase
            teamsListView->Items->Clear();                   // Clear ListView items

            // Filter teams by name or rank
            for (int i = 0; i < teamCount; i++) {
                String^ teamName = gcnew String(teams[i].name.c_str());
                String^ rank = teams[i].rank.ToString();

                if (searchText->Length == 0 || teamName->ToLower()->Contains(searchText) || rank->Contains(searchText)) {
                    ListViewItem^ item = gcnew ListViewItem(teamName);
                    item->SubItems->Add(gcnew String(teams[i].leadName.c_str()));
                    item->SubItems->Add(rank);
                    teamsListView->Items->Add(item);
                }
            }
        }

        // OnTeamSelected: Handles the event when a team is selected from ListView
        void OnTeamSelected(Object^ sender, EventArgs^ e) {
            int selectedIndex = teamsListView->FocusedItem->Index; // Get the selected index

            // Get the selected team's rank from the ListView
            int selectedRank = Int32::Parse(teamsListView->FocusedItem->SubItems[2]->Text);

            // Find the corresponding team based on rank
            Team* selectedTeam = nullptr;
            for (int i = 0; i < teamCount; i++) {
                if (teams[i].rank == selectedRank) {
                    selectedTeam = &teams[i];
                    break;
                }
            }

            // Open Team Details Form for the selected team
            if (selectedTeam != nullptr) {
                TeamDetailsForm^ detailsForm = gcnew TeamDetailsForm(selectedTeam);
                detailsForm->ShowDialog(); // Display the details form as a dialog
            }
        }

        // OnBack: Closes the current form and navigates back
        void OnBack(Object^ sender, EventArgs^ e) {
            this->Close(); // Close the current form
        }
    };
}
