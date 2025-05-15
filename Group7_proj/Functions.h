#include <iostream>
#include <string>
#include <fstream>

using namespace std;

//Struct Data Type to Store Rules
struct Rules {
	string num;
	string applied;
	string ip_pro;
	string decision;
};//End of Rules Struct Data Type

//Struct Data Type to Store Traffic
struct Traffic {
	string source_ip;
	string destination_ip;
	string protocol;
	string data;
	string rule_num;
	string decision_applied;
};//End of Traffic Struct Data type

string remove_str(string str, string remove)
{
	int pos = str.find(remove) + remove.length();
	str.erase(0, pos);
	return str;
}

//Opening Rules Files and Storing them
bool Store_Rules(Rules rules[])
{
	string tempStore;		//For temporarily storing rules

	//Opening the Rules File
	ifstream Rule_File("D:/rules.txt");

	//Checking if the Rule has opened
	if (!Rule_File) {	//If not opened, will return 0
		cout << "Rule File Not Found";
		return 0;
	}//End of if 
	else { //If opened, will store all the rules and return 1
		int i = 0;
		while (getline(Rule_File, tempStore)) {
			// Assuming each line in the file corresponds to a rule
			size_t pos = tempStore.find(' ');
			rules[i].num = tempStore.substr(0, pos);
			tempStore.erase(0, pos + 1);
			pos = tempStore.find(' ');
			rules[i].applied = tempStore.substr(0, pos);
			tempStore.erase(0, pos + 1);
			pos = tempStore.find(' ');
			rules[i].ip_pro = tempStore.substr(0, pos);
			tempStore.erase(0, pos + 1);
			pos = tempStore.find('\t');
			rules[i].decision = tempStore.substr(0, pos);
			i++;
		}//End of while

		Rule_File.close();	//Closing Rule_File, assuming we have all the rules
		return 1;
	}//End of else
}//End of Store_Rules Function

//Opening Traffic_File and reading the traffic
bool Read_TrafficData(Traffic traffic[])
{
	//Opening the Traffic File
	ifstream Traffic_File("D:/TrafficData.txt");

	//Checking If the file has opened
	if (!Traffic_File) {	//If not opened, will return 0
		cout << "File not opened";
		return 0;
	}//End of if
	else {	//If opened, will read all the traffic data and return 1
		int j = 0;
		string tempdata;
		char ch;
		while (Traffic_File >> ch) {
			if (ch == '[') {
				getline(Traffic_File, tempdata, ';');
				traffic[j].source_ip = remove_str(tempdata, "SRC:");
				getline(Traffic_File, tempdata, ';');
				traffic[j].destination_ip = remove_str(tempdata, "DST:");
				getline(Traffic_File, tempdata, ';');
				traffic[j].protocol = remove_str(tempdata, "PRO:");
				getline(Traffic_File, tempdata, ']');
				traffic[j].data = tempdata;
				ch = ' ';
				j++;
			}//End of if 
		}//End of while

		Traffic_File.close();	//Closing Traffic_File, assuming the traffic flow has stopped
		return 1;
	}//End of else
}

//Applying Rules on Traffic Data
void Apply_Rules(Rules rules[], Traffic traffic[])
{
	//Nested loops to check each traffic data against each rule
	for (int i = 0; i < 50; i++) {
		for (int j = 0; j < 30; j++) {
			if (rules[j].applied == "SRC") {	//If the rule is applied to source ip
				if (traffic[i].source_ip == rules[j].ip_pro) {
					traffic[i].rule_num = rules[j].num;
					traffic[i].decision_applied = rules[j].decision;
					break;
				}// End of if that compares rules with traffic
			}//End of if which tell where to apply
			else if (rules[j].applied == "DST") {	//If the rule is applied to destination ip
				if (traffic[i].destination_ip == rules[j].ip_pro) {
					traffic[i].rule_num = rules[j].num;
					traffic[i].decision_applied = rules[j].decision;
					break;
				}// End of if that compares rules with traffic
			}//End of else-if which tell where to apply
			else if (rules[j].applied == "PRO") {	//If the rule is applied to protocol
				if (traffic[i].protocol == rules[j].ip_pro) {
					traffic[i].rule_num = rules[j].num;
					traffic[i].decision_applied = rules[j].decision;
					break;
				}// End of if that compares rules with traffic
			}//End of else-if which tell where to apply
			else {	//If all rules don't apply then
				traffic[i].decision_applied = "DENY";
			}//End of else
		}//End of j for
	}//End of i for
}//End of Apply_Rules Functions

void Store_Result(Traffic traffic[])
{
	//Opening Result File to Store result
	ofstream resultFile("D:/result.txt");

	if (!resultFile) {	//If the file is not opened
		cout << "File not opened";
	}
	else {	//If the file is opened 
		//Loop to store the results
		for (int i = 0; i < 50; i++) {
			resultFile << "SRC " << traffic[i].source_ip << " "
				<< "DST " << traffic[i].destination_ip << " "
				<< "PRO " << traffic[i].protocol << " "
				<< traffic[i].decision_applied << " "
				<< traffic[i].rule_num << endl;
		}//End of Loop
	}//End of else
}//End of Store_Result Function
