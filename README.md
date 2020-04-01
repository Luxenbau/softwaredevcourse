# softwaredevcourse
my software dev project for the software development course 
A MVP version of my app is available for download. This is a MVP, and as such only the basic necessary functionality is implemented.

In order to run the project on your desktop machine you need :
1) To download the project.
2) Have unity installed on your machine along with unity editor of recent version with android build support.

To install unity do the following.
1) Go to : https://unity3d.com/get-unity/download
2) Select *Download Unity Hub *
3) Download and install Unity Hub. Register an account if it is necessary.
4) Launch unity hub, update it if needed.
5) In unity hub, on the left side there will be 4 tabs (projects, learn, community, installs ). Open the installs tab.
6) In the installs tab, click on the *Add* button, a new window will pop up asking you to choose the unity editor version to install. 
This project was recently updated to version 2019.3.6f1. Select that version, or the more recent one ( 2019.3.7f1 is the most recent as of 31.03 ).
7) Once you choose the version, click next. The *Add modules to install * page will open up, in here, choose Android Build Support.
8) Click Done. Unity will then proceed to install the ediot as well as android build files.
9) Once the installation is finished, go to the projects tab in unity hub. Click the Add button on the right. Find the folder with the project, and select it. The project will be displayed in the projects tab, click on it to open it. Allow unity to build the project.
NB! Make sure to allow unity internet acces through firewall if it requests it.
10) Once the project is open, you will see unity's main editor interface and tabs. In the lower part of the screen you will see the project 
assets folder and all files within, holding subfolders and scripts in it. In here, double click the *Game* scene ( the one with unity logo).
11) Once the scene is open, you will see the hierarchy updated on the left side, as well as the first screen loaded into the scene tab in the
middle of the editor ( there are a few tabs in the middle - Scene,Asset store, Game ).
12) Click on the Game tab ( it has a gamepad icon on the left of it ). Right under the game tab, a settings panel will be visible. In it,
you must adjust the aspect ratio and resolution ( by default unity loads the project as windows-based application and does not use mobile 
resolutions or format ). After Display1 there will be an option called *Aspect ratio*, likely with the option *Free aspect* selected. Click here.
13) A drop down window will open with desktop aspect ratios, at the bottom there will be a plus(+) sign, press this to add the
required resolution. Give it a name(label), and set it to 1080x1920. Clock Ok.
14) After the aspect ratio option, there is a scale slider. We do not need any scaling of screen, so bring it to minimum.
15) At this point you should see a portrait-like mobile screen, with the party select screen. If it is so, then press the play button,
which is located in the top middle of the editor ( with pause and stop buttons alongside it ).
16) The app should be up and running now.

To view the code:
All of the relevant code is kept in separate C# script files that are in the assets folder. Double click on them to open them up and view the code.

App details:

Party tab:
In this tab the current party and player characters are kept for the DM to access them at any time. Press the big add button to get the characters
from the database, select/deselect characters that you wish to add to the party.Scroll holding mouse button. Press New to add a new character, enter the fields, the
character will be stored in the firebase realtime database. You can then add them to the party.

Enemy tab: Here we will select the pre-stored opponents from the official DND manual. Since their data does not change, they will not be
stored in the online database. As this version is an MVP, there are 2 monsters added for demonstration purposes.
Click on the Add monster button, then click on 1 of the 2 enemies present. Select the amount of enemies of this type will be in the encounter.
To delete an enemy, select the ones you want to delete, press the delete button. Once you have enemies and players prepared. go to the battle tab.

Battle tab: This tab becomes available after both enemies and players have been selected. Press the start encounter button. Here you must 
now roll initiative for the participating characters, click on a character to manually enter their initiative, press on *roll* if you want
to auto-roll the initiative for those you dont want to enter manually. The initiative modifiers are auto-applied. Once all characters have
their initiative set, press the confirm button. You will then be sent to the battle management page. In here the DM can see the order of the characters 
that are in battle, by pressing the next turn button the current character will end their turn and the next one will appear on top. This
screen is used by the DM to monitor the battle sequence. Press the end battle button to end the battle, in order to adjust the amount of participating
characters.

This app is an early alpha version, there are many additional functionalities that could be implemented in the future. With the time limit I
had, this is what I produced, a basic MVP. Continuing development of the app will require substantial investment of time and resources.
Thank you for the attention!



