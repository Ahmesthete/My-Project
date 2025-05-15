#pragma once
#include "Team.h"

namespace project53 {

    using namespace System;
    using namespace System::Windows::Forms;
    using namespace System::Drawing;

    public ref class TeamDetailsForm : public Form {
    private:
        Label^ teamNameLabel;       // Label to display the team name
        Label^ leadDetailsLabel;   // Label to display the team lead details
        Label^ memberDetailsLabel; // Label to display the team members' details
        Button^ backButton;        // Button to navigate back to the previous screen
        Team* team;                // Pointer to the selected team object

    public:
        // Constructor to initialize the TeamDetailsForm with the selected team's data
        TeamDetailsForm(Team* selectedTeam) {
            // Configure form properties
            this->Text = "Team Details";
            this->Size = Drawing::Size(800, 600);
            this->BackColor = Color::Black;
            this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog; // Fixed dialog style
            this->MaximizeBox = false; // Disable the maximize button
            this->StartPosition = FormStartPosition::CenterScreen; // Center the form on the screen

            team = selectedTeam; // Assign the selected team

            // Heading Label
            Label^ heading = gcnew Label();
            heading->Text = "TEAM DETAILS"; // Heading text
            heading->ForeColor = Color::White; // Text color
            heading->Font = gcnew Drawing::Font("Arial", 20, FontStyle::Bold); // Font style and size
            heading->Size = Drawing::Size(400, 40); // Label size
            heading->Location = Point(200, 20); // Position on the form
            heading->TextAlign = ContentAlignment::MiddleCenter; // Center alignment
            this->Controls->Add(heading);

            // Team Name Label
            teamNameLabel = gcnew Label();
            teamNameLabel->Text = "Team Name: " + gcnew String(team->name.c_str()); // Display team name
            teamNameLabel->ForeColor = Color::White;
            teamNameLabel->Font = gcnew Drawing::Font("Arial", 14, FontStyle::Bold);
            teamNameLabel->Size = Drawing::Size(700, 30);
            teamNameLabel->Location = Point(50, 80);
            this->Controls->Add(teamNameLabel);

            // Lead Details Label
            leadDetailsLabel = gcnew Label();
            leadDetailsLabel->Text = "Lead:\n" +
                "Name: " + gcnew String(team->leadName.c_str()) + "\n" +
                "Gender: " + gcnew String(team->leadGender.c_str()) + "\n" +
                "Contact: " + gcnew String(team->leadContact.c_str()) + "\n" +
                "Email: " + gcnew String(team->leadEmail.c_str()); // Display lead details
            leadDetailsLabel->ForeColor = Color::White;
            leadDetailsLabel->Font = gcnew Drawing::Font("Arial", 12);
            leadDetailsLabel->Size = Drawing::Size(700, 100);
            leadDetailsLabel->Location = Point(50, 130);
            this->Controls->Add(leadDetailsLabel);

            // Member Details Label
            memberDetailsLabel = gcnew Label();
            memberDetailsLabel->Text = "Members:\n"; // Heading for members
            for (int i = 0; i < 2; i++) { // Loop to display all team members
                if (!team->members[i].name.empty()) {
                    memberDetailsLabel->Text +=
                        "Name: " + gcnew String(team->members[i].name.c_str()) + "\n" +
                        "Gender: " + gcnew String(team->members[i].gender.c_str()) + "\n" +
                        "Contact: " + gcnew String(team->members[i].contact.c_str()) + "\n" +
                        "Email: " + gcnew String(team->members[i].email.c_str()) + "\n\n";
                }
            }
            memberDetailsLabel->ForeColor = Color::White;
            memberDetailsLabel->Font = gcnew Drawing::Font("Arial", 12);
            memberDetailsLabel->Size = Drawing::Size(700, 250);
            memberDetailsLabel->Location = Point(50, 250);
            this->Controls->Add(memberDetailsLabel);

            // Back Button
            backButton = gcnew Button();
            backButton->Text = "Back"; // Button text
            backButton->Location = Point(350, 520);
            backButton->Size = Drawing::Size(100, 40); // Button size
            backButton->BackColor = Color::Red; // Button background color
            backButton->ForeColor = Color::White; // Button text color
            backButton->Click += gcnew EventHandler(this, &TeamDetailsForm::OnBack); // Event handler for back button
            this->Controls->Add(backButton);
        }

        // Event handler for the back button
        void OnBack(Object^ sender, EventArgs^ e) {
            this->Close(); // Close the current form and return to the previous screen
        }
    };
}
