#pragma once
#include "Scheduler.h"
#include <queue>

namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;

    public ref class PoolsForm : public Form {
    private:
        ListBox^ poolAlphaListBox;       // ListBox to display teams in Pool Alpha
        ListBox^ poolBetaListBox;        // ListBox to display teams in Pool Beta
        Button^ backButton;              // Button to navigate back to the previous screen
        TextBox^ searchTextBox;          // TextBox for searching teams
        Button^ searchButton;            // Button to trigger the search
        Label^ searchResultLabel;        // Label to display search results

    public:
        // Constructor to initialize the PoolsForm with Pool Alpha and Pool Beta data
        PoolsForm(std::queue<Team*> poolAlpha, std::queue<Team*> poolBeta) {
            this->Text = "Tournament Pools"; // Form title
            this->Size = Drawing::Size(800, 600); // Set form size
            this->BackColor = Color::Black; // Background color

            // Header Label
            Label^ heading = gcnew Label();
            heading->Text = "TOURNAMENT POOLS"; // Heading text
            heading->ForeColor = Color::White; // Text color
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold); // Font style and size
            heading->Size = Drawing::Size(400, 40); // Label size
            heading->Location = Point(200, 20); // Position on the form
            heading->TextAlign = ContentAlignment::MiddleCenter; // Center alignment
            this->Controls->Add(heading);

            // Pool Alpha Label
            Label^ poolAlphaLabel = gcnew Label();
            poolAlphaLabel->Text = "Pool Alpha (Rank 1–8)"; // Label for Pool Alpha
            poolAlphaLabel->ForeColor = Color::White;
            poolAlphaLabel->Font = gcnew Drawing::Font("Arial", 12, FontStyle::Bold);
            poolAlphaLabel->Size = Drawing::Size(200, 30);
            poolAlphaLabel->Location = Point(100, 70);
            this->Controls->Add(poolAlphaLabel);

            // Pool Beta Label
            Label^ poolBetaLabel = gcnew Label();
            poolBetaLabel->Text = "Pool Beta (Rank 9–16)"; // Label for Pool Beta
            poolBetaLabel->ForeColor = Color::White;
            poolBetaLabel->Font = gcnew Drawing::Font("Arial", 12, FontStyle::Bold);
            poolBetaLabel->Size = Drawing::Size(200, 30);
            poolBetaLabel->Location = Point(450, 70);
            this->Controls->Add(poolBetaLabel);

            // Pool Alpha ListBox
            poolAlphaListBox = gcnew ListBox();
            poolAlphaListBox->Location = Point(100, 100); // Position on the form
            poolAlphaListBox->Size = Drawing::Size(250, 300); // Set size
            poolAlphaListBox->BackColor = Color::Black; // Background color
            poolAlphaListBox->ForeColor = Color::White; // Text color
            this->Controls->Add(poolAlphaListBox);

            // Pool Beta ListBox
            poolBetaListBox = gcnew ListBox();
            poolBetaListBox->Location = Point(450, 100);
            poolBetaListBox->Size = Drawing::Size(250, 300);
            poolBetaListBox->BackColor = Color::Black;
            poolBetaListBox->ForeColor = Color::White;
            this->Controls->Add(poolBetaListBox);

            // Search TextBox
            searchTextBox = gcnew TextBox();
            searchTextBox->Location = Point(100, 420); // Position for search bar
            searchTextBox->Size = Drawing::Size(200, 30); // Size for search bar
            this->Controls->Add(searchTextBox);

            // Search Button
            searchButton = gcnew Button();
            searchButton->Text = "Search"; // Button text
            searchButton->Location = Point(320, 420);
            searchButton->Size = Drawing::Size(80, 30);
            searchButton->BackColor = Color::Blue;
            searchButton->ForeColor = Color::White;
            searchButton->Click += gcnew EventHandler(this, &PoolsForm::OnSearch); // Event handler for search button
            this->Controls->Add(searchButton);

            // Search Result Label
            searchResultLabel = gcnew Label();
            searchResultLabel->ForeColor = Color::White; // Text color
            searchResultLabel->Font = gcnew Drawing::Font("Arial", 12);
            searchResultLabel->Size = Drawing::Size(400, 30); // Label size
            searchResultLabel->Location = Point(100, 470); // Position on the form
            this->Controls->Add(searchResultLabel);

            // Back Button
            backButton = gcnew Button();
            backButton->Text = "Back"; // Button text
            backButton->Location = Point(350, 520);
            backButton->Size = Drawing::Size(100, 40);
            backButton->BackColor = Color::Red;
            backButton->ForeColor = Color::White;
            backButton->Click += gcnew EventHandler(this, &PoolsForm::OnBack); // Event handler for back button
            this->Controls->Add(backButton);

            // Load data into the Pool ListBoxes
            LoadPools(poolAlpha, poolBeta);
        }

        // Load teams into Pool Alpha and Pool Beta ListBoxes
        void LoadPools(std::queue<Team*> poolAlpha, std::queue<Team*> poolBeta) {
            while (!poolAlpha.empty()) { // Loop through Pool Alpha
                Team* team = poolAlpha.front();
                poolAlpha.pop();
                poolAlphaListBox->Items->Add("Rank " + team->rank + ": " + gcnew String(team->name.c_str())); // Add team details to ListBox
            }

            while (!poolBeta.empty()) { // Loop through Pool Beta
                Team* team = poolBeta.front();
                poolBeta.pop();
                poolBetaListBox->Items->Add("Rank " + team->rank + ": " + gcnew String(team->name.c_str())); // Add team details to ListBox
            }
        }

        // Event handler for Search Button click
        void OnSearch(Object^ sender, EventArgs^ e) {
            String^ searchText = searchTextBox->Text->Trim(); // Get search text
            if (String::IsNullOrEmpty(searchText)) { // Check if search text is empty
                searchResultLabel->Text = "Please enter a valid team name or rank."; // Display message
                return;
            }

            bool found = false;

            // Search in Pool Alpha
            for each (String ^ item in poolAlphaListBox->Items) {
                if (item->Contains(searchText)) {
                    searchResultLabel->Text = "Found in Pool Alpha: " + item; // Display result
                    found = true;
                    break;
                }
            }

            // Search in Pool Beta if not found in Pool Alpha
            if (!found) {
                for each (String ^ item in poolBetaListBox->Items) {
                    if (item->Contains(searchText)) {
                        searchResultLabel->Text = "Found in Pool Beta: " + item; // Display result
                        found = true;
                        break;
                    }
                }
            }

            // If not found in either pool
            if (!found) {
                searchResultLabel->Text = "Team not found.";
            }
        }

        // Event handler for Back Button click
        void OnBack(Object^ sender, EventArgs^ e) {
            this->Close(); // Close the current form
        }
    };
}
