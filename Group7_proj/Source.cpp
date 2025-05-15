#include "Functions.h"

int main()
{
    int a, b;
    Rules rules[30];
    Traffic traffic[50];

    a = Store_Rules(rules);

    if (a == 0) {
        cout << "There is an Error in the Program" << endl;
        return 0;
    }
    else {
        b = Read_TrafficData(traffic);
    }

    if (b == 0) {
        cout << "There is an Error in the Program" << endl;
        return 0;
    }
    else {
        Apply_Rules(rules, traffic);
    }

    Store_Result(traffic);

    cout << "Program Has Executed Successfully" << endl;

    return 1;
}
