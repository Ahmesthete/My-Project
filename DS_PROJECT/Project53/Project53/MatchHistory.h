#pragma once
#include "Match.h"
#include <queue>
#include <string>
#include <msclr/marshal_cppstd.h>

namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;
    using namespace std; 

    // MatchHistoryForm: Displays the history of completed matches
    public ref class MatchHistoryForm : public Form {
    private:
        ListBox^ matchHistoryBox; // ListBox to display match history

    public:
        // Constructor: Initializes the form and populates match history
        MatchHistoryForm(std::queue<Match*> matchHistory) {
            // Set the form properties
            this->Text = "Match History"; // Title of the form
            this->Size = Drawing::Size(800, 600); // Set form size
            this->BackColor = Color::Black; // Set background color

            // Initialize ListBox for displaying match history
            matchHistoryBox = gcnew ListBox();
            matchHistoryBox->Location = Point(50, 50); // Position of the ListBox
            matchHistoryBox->Size = Drawing::Size(700, 500); // Size of the ListBox
            matchHistoryBox->BackColor = Color::Black; // Background color of the ListBox
            matchHistoryBox->ForeColor = Color::White; // Text color in the ListBox

            // Populate the ListBox with match history details
            while (!matchHistory.empty()) {
                Match* match = matchHistory.front(); // Get the match from the queue
                matchHistory.pop(); // Remove the match from the queue

                // Format match details into a string
                String^ matchDetails = gcnew String((match->team1->name + " vs " + match->team2->name +
                    " - Winner: " + match->winner->name +
                    " - Date/Time: " + match->dateTime).c_str());

                // Add the formatted match details to the ListBox
                matchHistoryBox->Items->Add(matchDetails);
            }

            // Add the ListBox to the form's controls
            this->Controls->Add(matchHistoryBox);
        }
    };
}
