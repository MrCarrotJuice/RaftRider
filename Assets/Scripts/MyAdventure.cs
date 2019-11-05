using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAdventure : MonoBehaviour{

    public delegate void TestDelegate(); // This defines what type of method you're going to call.
    public TestDelegate FunctionToCall; // Container voor een functie

    // States houd bij welk moment de speler
    private enum States{
       mainmenu,
       credits,
       intro,
       geenhesje,
       keuzestuurman,
       raftzwaar,
       vastwater,
       tweesplitsing,
       rechts1,
       rechts2,
       links1,
       links2,
       mats,
       raftbotsing,
       aankomst,

       
    }

    private float stuurman = 0;

    // Als WrongInputState True is dan moet de speler eerst een random input doen om verder te kunnen met het spel
    private bool WrongInputState = false;
    
    // Deze variabele houd de huidige state van de game bij
    private States currentState = States.mainmenu;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    

    void OnUserInput(string input){
        if (WrongInputState == false){
            switch(currentState){
                
                //TEMPlATE NEW CASE
                //----------------------------------------------------------------------
                /*
                case States.xxxxxx:
                    if (input == "XXXXXX"){
                        FUNCTION();
                    }
                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = ShowMainMenu;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = FUNCTION;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;
                 */

                //main menu
                case States.mainmenu:
                    if (input == "start"){
                        StartIntro();
                    }
                    else if (input == "credits"){
                        ShowCredits();
                    }
                    else if (input == ""){
                        //als de speler alleen maar op enter (niks intypt) drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = ShowMainMenu;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = ShowMainMenu;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                case States.credits:
                    if (input == "terug"){
                        ShowMainMenu();
                    }
                    
                    else if (input == ""){
                        //als de speler alleen maar op enter (niks intypt) drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = ShowCredits;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = ShowCredits;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                //intro part 1
                case States.intro:
                    if (input == "vest"){
                        StartKeuzestuurman();
                    }

                    else if (input == "gaan"){
                        StartGeenhesje();
                    }

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartIntro;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartIntro;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                //intro part 2
                 case States.geenhesje:
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

            

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartGeenhesje;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartGeenhesje;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }

                
                break;
                case States.raftzwaar:
                   
                    if (input == "bagage"){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartGeenhesje;
                        WrongInput(FunctionToCall);
                    
                    }
                    else if (input == "mensoffer"){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartTweesplitsing;
                        WrongInput(FunctionToCall);
                        
                    }
                     else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartRaftzwaar;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartRaftzwaar;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }

                
                break;
                //death well
                case States.tweesplitsing:
                    if (input == "links" && stuurman == 0){
                            StartLinksGeert();
                    }
                    else if (input == "links" && stuurman == 2){
                            StartLinksBob();
                    }

                    else if (input == "rechts" && stuurman == 0){
                            StartRechtsGeert();
                    }
                    else if (input == "rechts" && stuurman == 2){
                            StartRechtsBob();
                    }
                    else if (input == "rechts" && stuurman == 1){
                            StartMats();
                    }
                    else if (input == "links" && stuurman == 1){
                            StartMats();
                    }

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartTweesplitsing;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartTweesplitsing;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                case States.keuzestuurman:

                
                    if (input == "geert"){
                        StartRaftzwaar();
                        stuurman = 0;
                    }

                    else if (input == "bob"){
                        StartRaftzwaar();
                        stuurman = 2;
                    }

                    else if (input == "mats"){
                        StartRaftzwaar();
                        stuurman = 1;
                    }

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartKeuzestuurman;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartKeuzestuurman;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                case States.rechts2:
                    
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

                

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartRechtsBob;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartRechtsBob;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                case States.rechts1:
                    
                    if (input == "duw"){
                        StartBotsing();
                    }

                    else if (input == "stuur"){
                        StartAankomst();
                    }

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartRechtsGeert;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartRechtsGeert;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }   
                break;

                case States.links1:
                    
                    if (input == "duw"){
                        StartBotsing();
                    }

                    else if (input == "stuur"){
                        StartAankomst();
                    }

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartLinksBob;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartLinksBob;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }   
                break;
                case States.links2:
                    
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

                

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartLinksGeert;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartLinksGeert;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;
                case States.mats:
                    
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

                

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartMats;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartMats;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;
                case States.raftbotsing:
                    
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

                

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartBotsing;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartBotsing;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;

                case States.aankomst:
                    
                    if (input == "opnieuw"){
                        ShowMainMenu();
                    }

                

                    else if (input == ""){
                        //als de speler alleen maar op enter drukt is het niet nodig om ze door het hele WrongInput menu te halen
                        FunctionToCall = StartAankomst;
                        WrongInput(FunctionToCall);
                    }
                    else{
                        // FunctionToCall vertelt de code naar welke functie de speler teruggestuurd moet worden
                        // in het geval dat ze een foute input geven en naar het WrongInputState menu gestuurd worden
                        FunctionToCall = StartAankomst;
                        WrongInputState = true;
                        Terminal.ClearScreen();
                        Terminal.WriteLine("Wrong input, press enter to continue");
                    }
                break;
                
                
            }
        }
        // als de WrongInputState true is dan moet de speler op enter drukken
        //(of iets randoms invoeren en dan op enter drukken) om het spel verder te laten gaan
        // dit moeten ze doen voordat ze een correcte input geven
        else if (WrongInputState == true){

            //de speler hoort deze if statement niet te kunnen voltooien, en deze if statement is bedoelt om altijd op de else uit te komen
            if(input == "8206209105760109857029835710984019248"){
                Terminal.WriteLine("Congrats you just managed to break the game");
            }
            //als deze else statement uitgevoerd wordt dan stuurt de game de speler met een functie terug naar het juiste moment in het spel
            else{
                WrongInput(FunctionToCall);
                
                WrongInputState = false;
            }
            
        }
    
        
    }
    //stuurt de speler vanuit de WrongInputState terug naar de het juiste moment, door de bijbehorende functie te activeren.
    void WrongInput(TestDelegate function){
        
        function();
            
    }
    //wordt door de start functie aangeroepen aan het begin van het spel
     void ShowMainMenu(){
        currentState = States.mainmenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("-RAFT RIDERS-");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO'S-------");
        Terminal.WriteLine("");
        Terminal.WriteLine("start - Start het spel");
        Terminal.WriteLine("credits - Ga naar het credits scherm");
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

    void retry(){
        ShowMainMenu();
    }

    void ShowCredits(){
        currentState = States.credits;
        Terminal.ClearScreen();
        Terminal.WriteLine("_-_-_-CREDITS-_-_-_");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("CODING: Quint Theissen");
        Terminal.WriteLine("ART: Quint Theissen");
        Terminal.WriteLine("TESTING: Flobatir Salama, Jaimy Dekker, Mahircan Alkan, Quint Theissen");
        Terminal.WriteLine("STORYLINE: Flobatir Salama, Jaimy Dekker, Mahircan Alkan, Quint Theissen");


        Terminal.WriteLine("");
        Terminal.WriteLine("FONT: dafont.com");
        Terminal.WriteLine("");
        Terminal.WriteLine("PROJECTBEGELEIDERS: J. Malotoux & S. Brouwer & G. Altink");
        
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO'S-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("terug - ga terug naar het hoofdmenu");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

    //eerste intro van het spel
    void StartIntro(){
        currentState = States.intro;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent mee op het introductiecamp van de ICT Academie.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Vandaag ga je met een groepje raften vanuit Maastricht naar Friesland.");
        Terminal.WriteLine("Je vind een groepje om mee te gaan raften, Geert, Mats, en Bob.");
        Terminal.WriteLine("Samen til je een raft naar het water, je bent de 2e raft  die vertrekt.");
        Terminal.WriteLine("Voordat je vertrekt besef je je dat het mischien handig is om een reddingsvest aan te doen.");
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO'S-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("vest - Doe een reddingsvest aan");
        Terminal.WriteLine("gaan - Ga in de raft zitten en vertrek");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   


    void StartGeenhesje(){
        currentState = States.geenhesje;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je klimt in de raft en begint te roeien.");
        Terminal.WriteLine("Helaas begint de raft te kantelen, omdat iedereen aan dezelfde kant is gaan zitten.");
        Terminal.WriteLine("Je bent nog geen 10 meter van de kust, en je raft kantelt om.");
        Terminal.WriteLine("Je valt in het water en beseft je dat je nooit hebt leren zwemmen!");
        
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");
        

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   

    void StartKeuzestuurman(){
        currentState = States.keuzestuurman;
        Terminal.ClearScreen();
        //empty line voor keuzes
        Terminal.WriteLine("Voordat je de raft instapt bedenk je je dat je raft nog geen stuurman heeft.");
        Terminal.WriteLine("Het lijkt je een goed idee om de leiding te nemen en een stuurman te kiezen!");

        Terminal.WriteLine("Geert: Geert lijkt fysiek helemaal in orde te zijn,");
        Terminal.WriteLine("       Maar is mischien niet de slimste. Hij lijkt je intelligent genoeg");
        Terminal.WriteLine("       om een peddel vast te houden.");

        Terminal.WriteLine("Bob: Bob is een jongen aan de wat zwaardere kant, Maar hij lijkt erg slim te zijn.");
 
        Terminal.WriteLine("Mats: Mats is een aparte jongen die het hele kamp nog geen zinnig woord heeft gezegd, ");
        Terminal.WriteLine("      je ziet niet in waarom hij een goede kandidaat zou zijn voor de positie stuurman.");
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO'S-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("geert - Kies Geert");
        Terminal.WriteLine("bob - Kies Bob");
        Terminal.WriteLine("mats - Kies Mats");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   
    void StartRaftzwaar(){
        currentState = States.raftzwaar;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je stapt met z'n allen in de raft en begint te roeien.");
        Terminal.WriteLine("Voor een minuut gaat alles goed, tot dat de raft lijkt te zinken");
        Terminal.WriteLine("onder het gewicht van de 4 passagiers.");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("");

        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO's-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("bagage - Gooi al je bagage en bezittingen over boord, in de hoop dat de raft blijft drijven.");
        if (stuurman==1){
            Terminal.WriteLine("mensoffer - Gooi de een-na zwaarste passagier overboord om het zinken te stoppen, jullie gaan Bob nodig hebben als stuurman!");
        }
        else {
           Terminal.WriteLine("mensoffer - Gooi de zwaarste passagier overboord om het zinken te stoppen."); 
        }
            

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   

     void StartVastwater(){
        currentState = States.vastwater;
        Terminal.ClearScreen();
        Terminal.WriteLine("Zo snel als je kan gooi je al de bagage weg om de raft drijvende te houden.");
        Terminal.WriteLine("Al je groepsgenoten kijken je heel boos aan.");
        Terminal.WriteLine("Als je om je heen kijkt zie je dat je in je haast ook alle peddels hebt weggegooid");
        Terminal.WriteLine("Je zit vast op het water");
        Terminal.WriteLine("");
        Terminal.WriteLine("");

        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");
        
            

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   

    void StartTweesplitsing(){
        currentState = States.tweesplitsing;
        Terminal.ClearScreen();
        Terminal.WriteLine("Het raften gaat een stuk makkelijker zonder dat extra gewicht, voordat je het weet ben je honderden meters verder!");
        Terminal.WriteLine("Na een tijdje zie je een tweesplitsing in de rivier, aan de rechterkant is een stroomversnelling en wordt de rivier erg snel en stijl,");
        Terminal.WriteLine("aan de linkerkant blijft de rivier rustig, maar er zijn allemaal scherpe rotsen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("");

        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO's-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("rechts - Probeer de boot recht te houden in de wilde stroomversnelling");
        Terminal.WriteLine("links - Probeer door de snelle rotsen te manoeuvreren");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }   

    void StartRechtsGeert(){
        currentState = States.rechts1;
        Terminal.ClearScreen();
        Terminal.WriteLine("Op goede hoop gaan jullie de stroomversnelling in.");
        Terminal.WriteLine("Door jullie stuurman Geert lukt het om de boot recht te houden in het wilde water.");
        Terminal.WriteLine("Jullie juichen omdat het gelukt is om langs de splitsing te komen.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Na een tijdje varen zien jullie een andere raft die direct op jullie af komt stormen,");
        Terminal.WriteLine("als jullie niks doen dan komt er geheid een botsing!");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO's-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("duw - Probeer de andere raft weg te duwen met je peddel");
        Terminal.WriteLine("stuur - Probeer weg te sturen van de andere raft");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

    void StartRechtsBob(){
        currentState = States.rechts2;
        Terminal.ClearScreen();
        Terminal.WriteLine("Op goede hoop gaan jullie de stroomversnelling in.");
        Terminal.WriteLine("Het lukt Bob niet om de raft recht te houden, en de raft crasht tegen de kust.");
        
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

    void StartLinksBob(){
        currentState = States.links1;
        Terminal.ClearScreen();
        Terminal.WriteLine("Op goede hoop gaan jullie links de puntige rotsen tegemoet.");
        Terminal.WriteLine("Jullie stuurman Bob komt op het goede idee om de boot stil te zetten en op de kust");
        Terminal.WriteLine("de boot langs de tweesplitsing te tillen.");
        Terminal.WriteLine("Jullie varen naar de kust en tillen de boot langs de rotsen, en duwen de boot weer in het water.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Na een tijdje varen zien jullie een andere raft die direct op jullie af komt stormen,");
        Terminal.WriteLine("als jullie niks doen dan komt er geheid een botsing!");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------COMMANDO's-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("duw - Probeer de andere raft weg te duwen met je peddel");
        Terminal.WriteLine("stuur - Probeer weg te sturen van de andere raft");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

        void StartLinksGeert(){
        currentState = States.links2;
        Terminal.ClearScreen();
        Terminal.WriteLine("Op goede hoop gaan jullie links de puntige rotsen tegemoet.");
        Terminal.WriteLine("Geert probeert voorzichtig door de rotsen heen te komen, maar halverwege de rotsen stuurt hij de boot vol tegen");
        Terminal.WriteLine("een puntige rots aan, hij dacht namelijk dat dat niet zo een probleem zou zijn. De boot gaat lek en zinkt met iedereen er in");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }
        void StartMats(){
        currentState = States.mats;
        Terminal.ClearScreen();
        Terminal.WriteLine("Als Mats de splitsing ziet krijgt hij een paniekaanval, ");
        Terminal.WriteLine("hij laat zijn peddel in het water vallen en gaat in foetuspositie in de boot liggen.");
        Terminal.WriteLine("Jullie stormen af op het eiland in het midden van de splitsing en de boot komt met een harde klap tot stilstand.");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }

    void StartAankomst(){
        currentState = States.aankomst;
        Terminal.ClearScreen();
        Terminal.WriteLine("Met al jullie kracht lukt het om de boot weg te sturen.");
        Terminal.WriteLine("Het kan niet lang meer duren voordat je bij het aankomstpunt arriveert.");
        Terminal.WriteLine("Je trekt een eindsprint om 1e te worden, en ziet in de verte het aankomstpunt.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Je bereikt als eerste raft het aankomstpunt.");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------SPEL GEWONNEN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
        }
          void StartBotsing(){
        currentState = States.raftbotsing;
        Terminal.ClearScreen();
        Terminal.WriteLine("Er breekt een gevecht uit tussen de 2 rafts, ");
        Terminal.WriteLine("Tijdens het vechten merken jullie niet dat jullie op een rots afstormen");
        
        //empty line voor keuzes
        Terminal.WriteLine("");
        Terminal.WriteLine("-------VERLOREN-------");
        Terminal.WriteLine("");

        Terminal.WriteLine("opnieuw - Ga terug naar het hoofdmenu en speel het spel opnieuw!");

        //empty line voor player input
        Terminal.WriteLine("");
        Terminal.WriteLine("----------------------");
        Terminal.WriteLine("");
    }
         
}
