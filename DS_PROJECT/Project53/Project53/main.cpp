#include "MyForm.h"

// Required namespaces for System and Windows Forms
using namespace System;
using namespace System::Windows::Forms;
using namespace project53; // Namespace for the project
using namespace std; 

// Entry point of the application
[STAThread]
int main(cli::array<System::String^>^ args) {
    // Enable visual styles for the application
    Application::EnableVisualStyles();

    // Set compatible text rendering for better UI rendering
    Application::SetCompatibleTextRenderingDefault(false);

    // Start the main application form (MyForm)
    Application::Run(gcnew MyForm());

   
    return 0;
}
