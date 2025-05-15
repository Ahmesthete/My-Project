#ifndef TEAM_H
#define TEAM_H

#include <string>

using namespace std;

// Member structure to store individual member details
struct Member {
    string name;      // Name of the member
    string gender;    // Gender of the member
    string contact;   // Contact number of the member
    string email;     // Email address of the member

    // Default constructor
    // Initializes all member details to empty strings
    Member() : name(""), gender(""), contact(""), email("") {}

    // Parameterized constructor
    // Initializes member details with provided values
    Member(string n, string g, string c, string e) : name(n), gender(g), contact(c), email(e) {}
};

// Team class to store team details
class Team {
public:
    string name;            // Name of the team
    string leadName;        // Name of the team leader
    string leadGender;      // Gender of the team leader
    string leadContact;     // Contact number of the team leader
    string leadEmail;       // Email address of the team leader
    Member members[2];      // Array to store details of two team members
    int memberCount;        // Number of members in the team (default is 0)
    int rank;               // Rank of the team (1–16 based on performance)

    // Default constructor
    // Initializes all team attributes to default values
    Team() : name(""), leadName(""), leadGender(""), leadContact(""), leadEmail(""), memberCount(0), rank(0) {}
};

#endif // TEAM_H
