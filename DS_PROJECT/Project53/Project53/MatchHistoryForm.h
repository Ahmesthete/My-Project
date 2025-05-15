#pragma once
#include "Match.h"
#include <string>
#include <msclr/marshal_cppstd.h>

using namespace std; 
namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;

    public ref class MatchHistoryForm : public Form {
    private:
        ListView^ matchHistoryListView; // ListView for better visualization of match history
        TextBox^ searchBox;            // Search bar for filtering matches
        Button^ searchButton;          // Search button to trigger search functionality
        Button^ backButton;            // Back button to navigate to the previous screen

        Match* matchHistoryArray;      // Pointer to match history array
        int matchCount;                // Total number of matches in history

    public:
        // Constructor accepting match history array and count
        MatchHistoryForm(Match* matches, int count) : matchHistoryArray(matches), matchCount(count) {
            // Form Properties
            this->Text = "Match History";
            this->Size = Drawing::Size(800, 600);
            this->BackColor = Color::Black;

            // Heading Label
            Label^ heading = gcnew Label();
            heading->Text = "MATCH HISTORY";
            heading->ForeColor = Color::White;
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold);
            heading->Size = Drawing::Size(400, 40);
            heading->Location = Point(200, 10);
            heading->TextAlign = ContentAlignment::MiddleCenter;
            this->Controls->Add(heading);

            // Search Bar
            searchBox = gcnew TextBox();
            searchBox->Location = Point(50, 70);
            searchBox->Size = Drawing::Size(500, 30);
            searchBox->BackColor = Color::White;
            searchBox->ForeColor = Color::Black;
            this->Controls->Add(searchBox);

            // Search Button
            searchButton = gcnew Button();
            searchButton->Text = "Search";
            searchButton->Location = Point(570, 70);
            searchButton->Size = Drawing::Size(100, 30);
            searchButton->BackColor = Color::Blue;
            searchButton->ForeColor = Color::White;
            searchButton->Click += gcnew EventHandler(this, &MatchHistoryForm::OnSearch);
            this->Controls->Add(searchButton);

            // Match History ListView
            matchHistoryListView = gcnew ListView();
            matchHistoryListView->View = View::Details; // Details view for better visualization
            matchHistoryListView->FullRowSelect = true; // Enable selection of the entire row
            matchHistoryListView->GridLines = true;     // Display grid lines for clarity
            matchHistoryListView->Location = Point(50, 120);
            matchHistoryListView->Size = Drawing::Size(700, 350);
            matchHistoryListView->BackColor = Color::Black;
            matchHistoryListView->ForeColor = Color::White;

            // Add Columns to ListView
            matchHistoryListView->Columns->Add("Match", 300); // Column for match details
            matchHistoryListView->Columns->Add("Winner", 200); // Column for winner details
            matchHistoryListView->Columns->Add("Date/Time", 200); // Column for date and time

            // Load match history into the ListView
            LoadMatchHistory();
            this->Controls->Add(matchHistoryListView);

            // Back Button
            backButton = gcnew Button();
            backButton->Text = "Back";
            backButton->Location = Point(350, 500);
            backButton->Size = Drawing::Size(100, 40);
            backButton->BackColor = Color::Red;
            backButton->ForeColor = Color::White;
            backButton->Click += gcnew EventHandler(this, &MatchHistoryForm::OnBack);
            this->Controls->Add(backButton);
        }

        // Load match history into ListView
        void LoadMatchHistory() {
            matchHistoryListView->Items->Clear(); // Clear existing items

            for (int i = 0; i < matchCount; i++) {
                Match match = matchHistoryArray[i];

                // Create ListViewItem with match details
                ListViewItem^ item = gcnew ListViewItem(gcnew String((match.team1->name + " vs " + match.team2->name).c_str()));
                item->SubItems->Add(gcnew String(match.winner->name.c_str())); // Add winner details
                item->SubItems->Add(gcnew String(match.dateTime.c_str())); // Add match date/time
                matchHistoryListView->Items->Add(item); // Add item to ListView
            }
        }

        // Handle Search Button click
        void OnSearch(Object^ sender, EventArgs^ e) {
            String^ query = searchBox->Text->ToLower(); // Convert search query to lowercase

            matchHistoryListView->Items->Clear(); // Clear existing items

            for (int i = 0; i < matchCount; i++) {
                Match match = matchHistoryArray[i];

                // Combine match details into a single string
                std::string matchDetails = match.team1->name + " " + match.team2->name + " " + match.winner->name;
                String^ matchDetailsManaged = gcnew String(matchDetails.c_str());

                // Check if the query matches any match details
                if (matchDetailsManaged->ToLower()->Contains(query)) {
                    ListViewItem^ item = gcnew ListViewItem(gcnew String((match.team1->name + " vs " + match.team2->name).c_str()));
                    item->SubItems->Add(gcnew String(match.winner->name.c_str()));
                    item->SubItems->Add(gcnew String(match.dateTime.c_str()));
                    matchHistoryListView->Items->Add(item); // Add matching item to ListView
                }
            }
        }

        // Handle Back Button click
        void OnBack(Object^ sender, EventArgs^ e) {
            this->Close(); // Close the Match History form
        }
    };
}
