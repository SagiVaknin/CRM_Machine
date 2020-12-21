#pragma once
#include <string>
#include <fstream>
namespace CRM {

	using namespace std;
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	private: System::Windows::Forms::Button^  T3_NTbutton;
	public:

	private: System::Windows::Forms::Label^  T3_l1;
	private: System::Windows::Forms::Button^  T3_UHbutton;

			 int i;
	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label1;
	protected:
	private: System::Windows::Forms::GroupBox^  ShortBox;
	private: System::Windows::Forms::Button^  loginButton;
	private: System::Windows::Forms::Label^  ShortLabel;
	private: System::Windows::Forms::Button^  TecButton;
	private: System::Windows::Forms::TabControl^  TabCon;
	private: System::Windows::Forms::TabPage^  T1WelTab;

	private: System::Windows::Forms::TabPage^  T2LoginTab;

	private: System::Windows::Forms::TabPage^  T3UserMenu;






	private: System::Windows::Forms::TabPage^  tabPage4;
	private: System::Windows::Forms::Label^  T1label2;
	private: System::Windows::Forms::Label^  T1label3;
	private: System::Windows::Forms::Button^  MainButton;
	private: System::Windows::Forms::Label^  T2_l3;
	private: System::Windows::Forms::Label^  T2_l2;
	private: System::Windows::Forms::Label^  T2_l1;
	private: System::Windows::Forms::TextBox^  T2_TBPW;
	private: System::Windows::Forms::TextBox^  T2_TBID;
	private: System::Windows::Forms::Button^  T2_ButNew;
	private: System::Windows::Forms::Button^  T2_LoginButton;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->ShortBox = (gcnew System::Windows::Forms::GroupBox());
			this->MainButton = (gcnew System::Windows::Forms::Button());
			this->TecButton = (gcnew System::Windows::Forms::Button());
			this->loginButton = (gcnew System::Windows::Forms::Button());
			this->ShortLabel = (gcnew System::Windows::Forms::Label());
			this->TabCon = (gcnew System::Windows::Forms::TabControl());
			this->T1WelTab = (gcnew System::Windows::Forms::TabPage());
			this->T1label3 = (gcnew System::Windows::Forms::Label());
			this->T1label2 = (gcnew System::Windows::Forms::Label());
			this->T2LoginTab = (gcnew System::Windows::Forms::TabPage());
			this->T2_LoginButton = (gcnew System::Windows::Forms::Button());
			this->T2_ButNew = (gcnew System::Windows::Forms::Button());
			this->T2_TBPW = (gcnew System::Windows::Forms::TextBox());
			this->T2_TBID = (gcnew System::Windows::Forms::TextBox());
			this->T2_l3 = (gcnew System::Windows::Forms::Label());
			this->T2_l2 = (gcnew System::Windows::Forms::Label());
			this->T2_l1 = (gcnew System::Windows::Forms::Label());
			this->T3UserMenu = (gcnew System::Windows::Forms::TabPage());
			this->tabPage4 = (gcnew System::Windows::Forms::TabPage());
			this->T3_l1 = (gcnew System::Windows::Forms::Label());
			this->T3_NTbutton = (gcnew System::Windows::Forms::Button());
			this->T3_UHbutton = (gcnew System::Windows::Forms::Button());
			this->ShortBox->SuspendLayout();
			this->TabCon->SuspendLayout();
			this->T1WelTab->SuspendLayout();
			this->T2LoginTab->SuspendLayout();
			this->T3UserMenu->SuspendLayout();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->BackColor = System::Drawing::Color::Transparent;
			this->label1->Font = (gcnew System::Drawing::Font(L"David", 36, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->label1->ForeColor = System::Drawing::SystemColors::ControlLight;
			this->label1->Location = System::Drawing::Point(188, 62);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(544, 47);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Academic support system";
			// 
			// ShortBox
			// 
			this->ShortBox->BackColor = System::Drawing::Color::Transparent;
			this->ShortBox->Controls->Add(this->MainButton);
			this->ShortBox->Controls->Add(this->TecButton);
			this->ShortBox->Controls->Add(this->loginButton);
			this->ShortBox->Controls->Add(this->ShortLabel);
			this->ShortBox->Location = System::Drawing::Point(1, 173);
			this->ShortBox->Name = L"ShortBox";
			this->ShortBox->Size = System::Drawing::Size(153, 425);
			this->ShortBox->TabIndex = 1;
			this->ShortBox->TabStop = false;
			// 
			// MainButton
			// 
			this->MainButton->BackColor = System::Drawing::Color::Transparent;
			this->MainButton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->MainButton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->MainButton->Location = System::Drawing::Point(15, 325);
			this->MainButton->Name = L"MainButton";
			this->MainButton->Size = System::Drawing::Size(109, 67);
			this->MainButton->TabIndex = 3;
			this->MainButton->Text = L"Back to\r\nmain menu\r\n";
			this->MainButton->UseVisualStyleBackColor = false;
			this->MainButton->Visible = false;
			this->MainButton->Click += gcnew System::EventHandler(this, &MyForm::MainButton_Click);
			// 
			// TecButton
			// 
			this->TecButton->BackColor = System::Drawing::Color::Transparent;
			this->TecButton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->TecButton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->TecButton->Location = System::Drawing::Point(15, 168);
			this->TecButton->Name = L"TecButton";
			this->TecButton->Size = System::Drawing::Size(109, 41);
			this->TecButton->TabIndex = 2;
			this->TecButton->Text = L"Technician";
			this->TecButton->UseVisualStyleBackColor = false;
			// 
			// loginButton
			// 
			this->loginButton->BackColor = System::Drawing::Color::Transparent;
			this->loginButton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->loginButton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->loginButton->Location = System::Drawing::Point(15, 86);
			this->loginButton->Name = L"loginButton";
			this->loginButton->Size = System::Drawing::Size(109, 41);
			this->loginButton->TabIndex = 1;
			this->loginButton->Text = L"Login";
			this->loginButton->UseVisualStyleBackColor = false;
			this->loginButton->Click += gcnew System::EventHandler(this, &MyForm::loginButton_Click);
			// 
			// ShortLabel
			// 
			this->ShortLabel->AutoSize = true;
			this->ShortLabel->Font = (gcnew System::Drawing::Font(L"David", 14.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->ShortLabel->Location = System::Drawing::Point(11, 16);
			this->ShortLabel->Name = L"ShortLabel";
			this->ShortLabel->Size = System::Drawing::Size(57, 19);
			this->ShortLabel->TabIndex = 0;
			this->ShortLabel->Text = L"Menu";
			// 
			// TabCon
			// 
			this->TabCon->Appearance = System::Windows::Forms::TabAppearance::Buttons;
			this->TabCon->Controls->Add(this->T1WelTab);
			this->TabCon->Controls->Add(this->T2LoginTab);
			this->TabCon->Controls->Add(this->T3UserMenu);
			this->TabCon->Controls->Add(this->tabPage4);
			this->TabCon->ItemSize = System::Drawing::Size(0, 1);
			this->TabCon->Location = System::Drawing::Point(149, 178);
			this->TabCon->Margin = System::Windows::Forms::Padding(0);
			this->TabCon->Multiline = true;
			this->TabCon->Name = L"TabCon";
			this->TabCon->SelectedIndex = 0;
			this->TabCon->Size = System::Drawing::Size(738, 420);
			this->TabCon->SizeMode = System::Windows::Forms::TabSizeMode::Fixed;
			this->TabCon->TabIndex = 2;
			// 
			// T1WelTab
			// 
			this->T1WelTab->BackColor = System::Drawing::Color::BlanchedAlmond;
			this->T1WelTab->BackgroundImageLayout = System::Windows::Forms::ImageLayout::None;
			this->T1WelTab->Controls->Add(this->T1label3);
			this->T1WelTab->Controls->Add(this->T1label2);
			this->T1WelTab->Location = System::Drawing::Point(4, 5);
			this->T1WelTab->Name = L"T1WelTab";
			this->T1WelTab->Padding = System::Windows::Forms::Padding(3);
			this->T1WelTab->Size = System::Drawing::Size(730, 411);
			this->T1WelTab->TabIndex = 0;
			this->T1WelTab->Text = L"WelTab";
			// 
			// T1label3
			// 
			this->T1label3->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T1label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 26.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T1label3->Location = System::Drawing::Point(105, 95);
			this->T1label3->Name = L"T1label3";
			this->T1label3->Size = System::Drawing::Size(573, 92);
			this->T1label3->TabIndex = 1;
			this->T1label3->Text = L"Please choose your choice\r\nFrom the side bar.\r\n";
			// 
			// T1label2
			// 
			this->T1label2->AutoSize = true;
			this->T1label2->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T1label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 26.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T1label2->Location = System::Drawing::Point(286, 20);
			this->T1label2->Name = L"T1label2";
			this->T1label2->Size = System::Drawing::Size(181, 39);
			this->T1label2->TabIndex = 0;
			this->T1label2->Text = L"Welcome!";
			// 
			// T2LoginTab
			// 
			this->T2LoginTab->BackColor = System::Drawing::Color::BlanchedAlmond;
			this->T2LoginTab->Controls->Add(this->T2_LoginButton);
			this->T2LoginTab->Controls->Add(this->T2_ButNew);
			this->T2LoginTab->Controls->Add(this->T2_TBPW);
			this->T2LoginTab->Controls->Add(this->T2_TBID);
			this->T2LoginTab->Controls->Add(this->T2_l3);
			this->T2LoginTab->Controls->Add(this->T2_l2);
			this->T2LoginTab->Controls->Add(this->T2_l1);
			this->T2LoginTab->Location = System::Drawing::Point(4, 5);
			this->T2LoginTab->Name = L"T2LoginTab";
			this->T2LoginTab->Padding = System::Windows::Forms::Padding(3);
			this->T2LoginTab->Size = System::Drawing::Size(730, 411);
			this->T2LoginTab->TabIndex = 1;
			this->T2LoginTab->Text = L"tabPage2";
			// 
			// T2_LoginButton
			// 
			this->T2_LoginButton->BackColor = System::Drawing::Color::Transparent;
			this->T2_LoginButton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T2_LoginButton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T2_LoginButton->Location = System::Drawing::Point(602, 330);
			this->T2_LoginButton->Name = L"T2_LoginButton";
			this->T2_LoginButton->Size = System::Drawing::Size(115, 52);
			this->T2_LoginButton->TabIndex = 7;
			this->T2_LoginButton->Text = L"->";
			this->T2_LoginButton->UseVisualStyleBackColor = false;
			this->T2_LoginButton->Click += gcnew System::EventHandler(this, &MyForm::T2_LoginButton_Click);
			// 
			// T2_ButNew
			// 
			this->T2_ButNew->BackColor = System::Drawing::Color::Transparent;
			this->T2_ButNew->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T2_ButNew->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T2_ButNew->Location = System::Drawing::Point(279, 247);
			this->T2_ButNew->Name = L"T2_ButNew";
			this->T2_ButNew->Size = System::Drawing::Size(147, 37);
			this->T2_ButNew->TabIndex = 4;
			this->T2_ButNew->Text = L"New Account";
			this->T2_ButNew->UseVisualStyleBackColor = false;
			// 
			// T2_TBPW
			// 
			this->T2_TBPW->Location = System::Drawing::Point(234, 179);
			this->T2_TBPW->Name = L"T2_TBPW";
			this->T2_TBPW->Size = System::Drawing::Size(138, 20);
			this->T2_TBPW->TabIndex = 6;
			// 
			// T2_TBID
			// 
			this->T2_TBID->Location = System::Drawing::Point(234, 122);
			this->T2_TBID->Name = L"T2_TBID";
			this->T2_TBID->Size = System::Drawing::Size(138, 20);
			this->T2_TBID->TabIndex = 5;
			// 
			// T2_l3
			// 
			this->T2_l3->AutoSize = true;
			this->T2_l3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T2_l3->Location = System::Drawing::Point(98, 175);
			this->T2_l3->Name = L"T2_l3";
			this->T2_l3->Size = System::Drawing::Size(106, 24);
			this->T2_l3->TabIndex = 4;
			this->T2_l3->Text = L"Password:";
			// 
			// T2_l2
			// 
			this->T2_l2->AutoSize = true;
			this->T2_l2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 14.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T2_l2->Location = System::Drawing::Point(169, 122);
			this->T2_l2->Name = L"T2_l2";
			this->T2_l2->Size = System::Drawing::Size(35, 24);
			this->T2_l2->TabIndex = 3;
			this->T2_l2->Text = L"ID:";
			// 
			// T2_l1
			// 
			this->T2_l1->AutoSize = true;
			this->T2_l1->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T2_l1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 26.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T2_l1->Location = System::Drawing::Point(236, 25);
			this->T2_l1->Name = L"T2_l1";
			this->T2_l1->Size = System::Drawing::Size(229, 39);
			this->T2_l1->TabIndex = 2;
			this->T2_l1->Text = L"Enter Details";
			// 
			// T3UserMenu
			// 
			this->T3UserMenu->BackColor = System::Drawing::Color::BlanchedAlmond;
			this->T3UserMenu->Controls->Add(this->T3_UHbutton);
			this->T3UserMenu->Controls->Add(this->T3_NTbutton);
			this->T3UserMenu->Controls->Add(this->T3_l1);
			this->T3UserMenu->Location = System::Drawing::Point(4, 5);
			this->T3UserMenu->Name = L"T3UserMenu";
			this->T3UserMenu->Padding = System::Windows::Forms::Padding(3);
			this->T3UserMenu->Size = System::Drawing::Size(730, 411);
			this->T3UserMenu->TabIndex = 2;
			this->T3UserMenu->Text = L"UserMenu";
			// 
			// tabPage4
			// 
			this->tabPage4->Location = System::Drawing::Point(4, 5);
			this->tabPage4->Name = L"tabPage4";
			this->tabPage4->Padding = System::Windows::Forms::Padding(3);
			this->tabPage4->Size = System::Drawing::Size(730, 411);
			this->tabPage4->TabIndex = 3;
			this->tabPage4->Text = L"tabPage4";
			this->tabPage4->UseVisualStyleBackColor = true;
			// 
			// T3_l1
			// 
			this->T3_l1->AutoSize = true;
			this->T3_l1->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T3_l1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 26.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T3_l1->Location = System::Drawing::Point(251, 19);
			this->T3_l1->Name = L"T3_l1";
			this->T3_l1->Size = System::Drawing::Size(195, 39);
			this->T3_l1->TabIndex = 8;
			this->T3_l1->Text = L"User Menu";
			// 
			// T3_NTbutton
			// 
			this->T3_NTbutton->BackColor = System::Drawing::Color::Transparent;
			this->T3_NTbutton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T3_NTbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T3_NTbutton->Location = System::Drawing::Point(120, 102);
			this->T3_NTbutton->Name = L"T3_NTbutton";
			this->T3_NTbutton->Size = System::Drawing::Size(173, 41);
			this->T3_NTbutton->TabIndex = 4;
			this->T3_NTbutton->Text = L"Create new ticket";
			this->T3_NTbutton->UseVisualStyleBackColor = false;
			// 
			// T3_UHbutton
			// 
			this->T3_UHbutton->BackColor = System::Drawing::Color::Transparent;
			this->T3_UHbutton->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->T3_UHbutton->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(0)));
			this->T3_UHbutton->Location = System::Drawing::Point(463, 102);
			this->T3_UHbutton->Name = L"T3_UHbutton";
			this->T3_UHbutton->Size = System::Drawing::Size(168, 41);
			this->T3_UHbutton->TabIndex = 9;
			this->T3_UHbutton->Text = L"User History";
			this->T3_UHbutton->UseVisualStyleBackColor = false;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->BackColor = System::Drawing::Color::BlanchedAlmond;
			this->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"$this.BackgroundImage")));
			this->ClientSize = System::Drawing::Size(882, 597);
			this->Controls->Add(this->TabCon);
			this->Controls->Add(this->ShortBox);
			this->Controls->Add(this->label1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
			this->Name = L"MyForm";
			this->Text = L"MyForm";
			this->ShortBox->ResumeLayout(false);
			this->ShortBox->PerformLayout();
			this->TabCon->ResumeLayout(false);
			this->T1WelTab->ResumeLayout(false);
			this->T1WelTab->PerformLayout();
			this->T2LoginTab->ResumeLayout(false);
			this->T2LoginTab->PerformLayout();
			this->T3UserMenu->ResumeLayout(false);
			this->T3UserMenu->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void loginButton_Click(System::Object^  sender, System::EventArgs^  e) {
		TabCon->SelectedIndex=1;
		loginButton->Visible = false;
		TecButton->Visible = false;
		MainButton->Visible = true;
	}
private: System::Void MainButton_Click(System::Object^  sender, System::EventArgs^  e) {
	TabCon->SelectedIndex = 0;
	loginButton->Visible = true;
	TecButton->Visible = true;
	MainButton->Visible = false;
}
private: System::Void T2_LoginButton_Click(System::Object^  sender, System::EventArgs^  e) {
	if (Verify_ID_and_Password())
	{
		TabCon->SelectedIndex = 2;
	}
		
}
bool Verify_ID_and_Password()
{
	//ID:324201600
	//Password:56489944
	if (!CheckPassword())
	{
		return false;
	}
	string pass;
	MarshalString(T2_TBPW->Text, pass);
	string Id;
	MarshalString(T2_TBID->Text, Id);
	string line;
	string flag;
	ifstream myfile("New.txt");
	if (myfile.is_open())
	{
		while (getline(myfile, line)) //write line by line into the string "line"
		{
			flag = line.substr(line.find(':') + 1, line.length());
			if (CheckID(Id, flag) == true) //Checks if the user is already existing in the program
			{
				getline(myfile, line);
				/*		flag = line.substr(line.find(':') + 1, line.length())
				name = flag;*/
				getline(myfile, line);
				getline(myfile, line);
				getline(myfile, line);
				flag = line.substr(line.find(':') + 1, line.length());
					if (Verify_Password(flag, pass) == true)
					{
						MessageBox::Show("Connected");
						myfile.close();
						return true;
					}
					else
					{
						MessageBox::Show("Incorrect password");
						myfile.close();
						return false;
					}
			}
		}
		myfile.close();
	}
	MessageBox::Show("User not found");

	return false;
}
bool Verify_Password(string CheckPass, string Pass)
{
	{
		if (CheckPass == Pass)
		{
			return true;
		}
		return false;
	}
}
bool CheckPassword()
{
	string password;
	MarshalString(T2_TBPW->Text, password);
	while (T2_TBPW->Text->Length < 8)
	{
		//cout << "Your password is too short,please try again" << endl;
		//cin >> password;
		MessageBox::Show("Your password is too short,please try again");
		return false;
	}
	while (T2_TBPW->Text->Length > 8)
	{
		MessageBox::Show("Your password is too long,please try again");

		//cout << "Your password is too long,please try again" << endl;
		//cin >> password;
		return false;
	}
	while (!(password.find("!") == string::npos) || !(password.find("@") == string::npos) || !(password.find("#") == string::npos) || !(password.find("$") == string::npos) || !(password.find("%") == string::npos) || !(password.find("^") == string::npos) || !(password.find("&") == string::npos) || !(password.find("*") == string::npos) || !(password.find("(") == string::npos) || !(password.find(")") == string::npos) || !(password.find("-") == string::npos) || !(password.find("+") == string::npos) || !(password.find("_") == string::npos) || !(password.find("=") == string::npos) || !(password.find(".") == string::npos) || !(password.find("[") == string::npos) || !(password.find("]") == string::npos))
	{
		MessageBox::Show("You have selected a password that contains a bad character, please try again");

		//cout << "You have selected a password that contains a bad character, please try again" << endl;
		//cin >> password;
		return false;
	}
	return true;
}
bool CheckID(string New_U, string Excist_U)
{
	if (New_U == Excist_U)
	{
		return true;
	}
	return false;
}
void MarshalString(String ^ s, string& os) //String ^ to string
{
	using namespace Runtime::InteropServices;
	const char* chars =
		(const char*)(Marshal::StringToHGlobalAnsi(s)).ToPointer();
	os = chars;
	Marshal::FreeHGlobal(IntPtr((void*)chars));
}

};
}
