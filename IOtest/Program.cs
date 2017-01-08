using System;
using System.Threading;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.GeneralPurpose.Behaviors;
using System.Net;
using System.Collections;

namespace IOtest
{
	/// <summary>
	/// This is a sample program. Must be modified to match your GPIO project.
	/// </summary>

	class Program
	{
		static GpioConnection connection;
		static InputPinConfiguration Blue1 = ConnectorPin.P1Pin37.Input (); //GPIO26
		static InputPinConfiguration Blue2 = ConnectorPin.P1Pin35.Input (); //GPIO19
		static InputPinConfiguration Blue3 = ConnectorPin.P1Pin33.Input (); //GPIO13
		static InputPinConfiguration Blue4 = ConnectorPin.P1Pin31.Input (); //GPIO6

		static InputPinConfiguration Rocker1 = ConnectorPin.P1Pin26.Input (); //GPIO8
		static InputPinConfiguration Rocker2 = ConnectorPin.P1Pin24.Input (); 
		static InputPinConfiguration Rocker3 = ConnectorPin.P1Pin40.Input (); 
		static InputPinConfiguration Rocker4 = ConnectorPin.P1Pin10.Input (); 

		static InputPinConfiguration KEY1A =ConnectorPin.P1Pin21.Input (); //GPIO7
		static InputPinConfiguration KEY1B = ConnectorPin.P1Pin19.Input (); //GPIO7

		static InputPinConfiguration POS1A=ConnectorPin.P1Pin29.Input ();
		static InputPinConfiguration POS1B=ConnectorPin.P1Pin23.Input ();
		static InputPinConfiguration POS1C=ConnectorPin.P1Pin15.Input ();

		static InputPinConfiguration FIREPULL=ConnectorPin.P1Pin38.Input ();



		static OutputPinConfiguration Rocker1LED=ConnectorPin.P1Pin22.Output ();
		static OutputPinConfiguration Rocker2LED=ConnectorPin.P1Pin18.Output ();
		static OutputPinConfiguration Rocker3LED=ConnectorPin.P1Pin5.Output ();
		static OutputPinConfiguration Rocker4LED=ConnectorPin.P1Pin3.Output ();

		static OutputPinConfiguration TopAmber=ConnectorPin.P1Pin11.Output ();
		static OutputPinConfiguration BottomAmber=ConnectorPin.P1Pin7.Output ();

		static OutputPinConfiguration RedNav=ConnectorPin.P1Pin36.Output ();
		static OutputPinConfiguration GreenNav=ConnectorPin.P1Pin32.Output ();

		static OutputPinConfiguration RightRed=ConnectorPin.P1Pin16.Output ();
		static OutputPinConfiguration LeftRed=ConnectorPin.P1Pin12.Output ();

		static OutputPinConfiguration BlueMaster=ConnectorPin.P1Pin13.Output ();


		static bool boxarmed = false;
		static bool boxfirepulled = false;
		static bool sound = false;
		static bool food = false;

		static public void initIO(){
		
			//INPUT PINS
			//			# #BLUESWITCHES
			Blue1.Resistor = PinResistor.PullDown;
			Blue2.Resistor = PinResistor.PullDown;
			Blue3.Resistor = PinResistor.PullDown;
			Blue4.Resistor = PinResistor.PullDown;

			//			Rocker Switches
			Rocker1.Resistor = PinResistor.PullDown;
			Rocker2.Resistor = PinResistor.PullDown;
			Rocker3.Resistor = PinResistor.PullDown;
			Rocker4.Resistor = PinResistor.PullDown;

			//KEY Switch
			KEY1A.Resistor = PinResistor.PullUp;
			KEY1A.Reversed = true;
			KEY1B.Resistor = PinResistor.PullUp;
			KEY1B.Reversed = true;

			//POSITION Switch
			POS1A.Resistor = PinResistor.PullUp;
			POS1A.Reversed = true;
			POS1B.Resistor = PinResistor.PullUp;
			POS1B.Reversed = true;
			POS1C.Resistor = PinResistor.PullUp;
			POS1C.Reversed = true;

			//PULL STATION
			FIREPULL.Resistor = PinResistor.PullUp;
			FIREPULL.Reversed = true;

			//OUTPUTS
			Rocker4LED.Reversed = true;
			TopAmber.Reversed = false;
			BottomAmber.Reversed = true;
			Rocker2LED.Reversed = true;
			LeftRed.Reversed = true;
			BlueMaster.Reversed = true;
			RedNav.Reversed = true;
			GreenNav.Reversed = true;

			connection = new GpioConnection (GreenNav, RedNav, BlueMaster, RightRed, LeftRed, Rocker1LED, Rocker2LED, Rocker3LED, Rocker4LED, BottomAmber, TopAmber, Blue1, Blue2, Blue3, Blue4, Rocker1, Rocker2, Rocker3, Rocker4, POS1A, POS1B, POS1C, KEY1A, KEY1B, FIREPULL);

		
		}


		static public void ALLON()
		{
			connection [Rocker1LED] = false;
			connection [Rocker2LED] = false;
			connection [Rocker3LED] = false;
			connection [Rocker4LED] = false;
			connection [TopAmber] = false;
			connection [BottomAmber] = false;
			connection [RedNav] = false;
			connection [GreenNav] = false;
			connection [BlueMaster] = false;
			connection [RightRed] = false;
			connection [LeftRed] = false;
		}

		static public void ALLOFF()
		{
			connection [Rocker1LED] = true;
			connection [Rocker2LED] = true;
			connection [Rocker3LED] = true;
			connection [Rocker4LED] = true;
			connection [TopAmber] = true;
			connection [BottomAmber] = true;
			connection [RedNav] = true;
			connection [GreenNav] = true;
			connection [BlueMaster] = true;
			connection [RightRed] = true;
			connection [LeftRed] = true;

		}



		static void Main (string[] args)
		{
			Console.Write ("start");
			Console.Write ("Hello worlds");

			initIO ();


			Console.WriteLine ("RPI inited");


			for (var i = 0; i < 2; i++) {
				// Toggle() switches the high/low (on/off) status of the pin
				Console.WriteLine ("ON");
				ALLON ();
				Console.Write ("BLUE SWITCHES\n");
				Console.Write (connection [Blue1]);
				Console.Write (connection [Blue2]);
				Console.Write (connection [Blue3]);
				Console.Write (connection [Blue4]);
				Console.WriteLine ("ROCKER SWITCHES\n");
				Console.Write (connection [Rocker1]);
				Console.Write (connection [Rocker2]);
				Console.Write (connection [Rocker3]);
				Console.Write (connection [Rocker4]);
				Console.WriteLine ("KEY\n");
				Console.Write (connection [KEY1A]);
				Console.Write (connection [KEY1B]);
				Console.WriteLine ("POSITION\n");
				Console.Write (connection [POS1A]);
				Console.Write (connection [POS1B]);
				Console.Write (connection [POS1C]);

				Console.WriteLine ("FIREPULL\n");
				Console.Write (connection [FIREPULL]);

				//				led4Pin.Output().Enable;
				System.Threading.Thread.Sleep (1000);
				Console.WriteLine ("OFF");
				ALLOFF ();
				System.Threading.Thread.Sleep (500);
			}

			redbeacon(false);
			greenbeacon (false);
			bluebeacon (false);
			boxarmed = false;
			boxfirepulled = false;
			sound = false;
			food = false;
	
			//MAIN LOOP
			while (true) {
				ALLOFF ();
				if (connection [KEY1A]) {
					boxarmed = false;
					noKey ();
				}

				else if (connection [Rocker1]) {
					if (!boxarmed) { //BOX GETTING ARMED NOW
						ringbell(25);
						redbeacon (true);
						boxarmed = true;
						if (connection [FIREPULL]) {
							Console.WriteLine ("ALARM ALREADY PULLED ERROR");
							boxfirepulled = true;
						}	
							
					}
					if (connection [FIREPULL]) { //IT's HAPPENING
						if (!boxfirepulled) {
							Console.WriteLine ("FIRED ORDER PIZZA");
							boxfired ();
							boxfirepulled = true;

						} 
						else {
							ALLOFF ();

							System.Threading.Thread.Sleep (5000);
							connection [RedNav] = false;
							System.Threading.Thread.Sleep (5000);
							connection [RedNav] = true;


						}
					}

					armedBlink ();

				} 
				else {
					if (boxarmed) { //BOX GETTING DEARMED NOW
						redbeacon(false);
						greenbeacon (false);
						bluebeacon (false);
						food = false;
						boxfirepulled = false;
						Console.WriteLine ("DEARMED");
					}
					boxarmed = false;
					standbyBlink ();

				}


			}

				
//				Console.Write ("\n"+connection [Rocker1]);
//				Console.Write (connection [Rocker2]);
//				Console.Write (connection [Rocker3]);
//				Console.Write (connection [Rocker4]);
//
//				System.Threading.Thread.Sleep (10000);

//			}





			connection.Close ();

		}


		static void noKey(){
			ALLOFF ();
			connection [RedNav] = false;
			for (int i = 0; i < 20; i++) {
				if (!connection [KEY1A])
					return;
				System.Threading.Thread.Sleep (100);
			}
			connection [RedNav] = true;
			for (int i = 0; i < 100; i++) {
				if (!connection [KEY1A])
					return;
				System.Threading.Thread.Sleep (100);
			}
//			Console.Write ("nokeyend");
		}


		static void standbyBlink(){
			ALLOFF ();
			connection [RedNav] = false;
			connection [Rocker1LED] = true;
			connection [Rocker2LED] = true;
			connection [Rocker3LED] = true;
			connection [Rocker4LED] = true;
			for (int i = 0; i < 15; i++) {
				if (connection [Rocker1])
					return;
				System.Threading.Thread.Sleep (100);
			}


			ALLOFF ();
			connection [RedNav] = true;
			connection [Rocker1LED] = false;
			connection [Rocker2LED] = false;
			connection [Rocker3LED] = false;
			connection [Rocker4LED] = false;
			for (int i = 0; i < 10; i++) {
				if (connection [Rocker1])
					return;
				System.Threading.Thread.Sleep (100);
			}
		}


		static void armedBlink(){
			ALLOFF ();
	
			sound = false;
			food = false;
			if (!connection [KEY1A] && connection [Rocker2]) { //SOUND ACTIVE
				connection [TopAmber] = false;
				connection [Rocker2LED] = false;
				sound = true;
			}
			
			if (connection [KEY1B] && connection [Rocker4]) { //FOOD ACTIVE
				connection [BottomAmber] = false;
				connection [Rocker4LED] = false;
				food = true;
			}

			connection [Rocker1LED] = false;
	
//			Console.WriteLine ("DEBUG/n");
//			Console.Write (connection[Blue1]);
//			Console.Write (connection[Blue2]);
//			Console.Write (connection[Blue3]);
//			Console.Write (connection[Blue4]);
//
//			Console.Write(getPOS ());


			System.Threading.Thread.Sleep (1000);


			ALLOFF ();
//			Console.Write (connection [Rocker4]);
			connection [GreenNav] = false;
			connection [BlueMaster] = false;


			connection [Rocker1LED] = false;
			connection [Rocker2LED] = false;
			connection [Rocker3LED] = false;
			connection [Rocker4LED] = false;

			System.Threading.Thread.Sleep (500);
		}


		static void boxfired(){
			Console.WriteLine ("FIRED FUNCTION");
			greenbeacon (true);
			connection [BlueMaster] = false;
			System.Threading.Thread.Sleep (500);
			if (sound) {
				ringbell (250);
				System.Threading.Thread.Sleep (250);
				ringbell (250);
				System.Threading.Thread.Sleep (250);
				ringbell (250);
				System.Threading.Thread.Sleep (250);
				ringbell (2000);

			}


			if (food) {
				bluebeacon (true);
				Console.WriteLine ("ORDER DOMINOS");
				Console.Write(getPOS ());
				if (connection [Blue1])
					Console.Write ("CHEESE PIZZA");
				if (connection [Blue2])
					Console.Write ("RONI PIZZA");
				if (connection [Blue3])
					Console.Write ("CINNASTIX");
				if (connection [Blue4])
					Console.Write ("CHEESEBREAD");
			}
		}


		static int getPOS(){
			if (connection [POS1A])
				return 4;
			else if (connection[POS1B])
				return 2;
			else if (connection[POS1C])
				return 3;
			else
				return 1;
		}


		static void ringbell(int time){
			var wb = new WebClient ();
			var url = "http://192.168.1.145/?CH=4&ACTION=BURST." + time.ToString ();
			try 
			{
				var response = wb.DownloadString(url);
			}
			catch (Exception x)
			{
				Console.WriteLine ("HTTP ERROR");
			}


						
		}
		static void bluebeacon(bool mode){
			var wb = new WebClient ();
			var url="";
			if(mode)
				url = "http://192.168.1.145/?CH=1&ACTION=SWITCHON";
			else
				url = "http://192.168.1.145/?CH=1&ACTION=SWITCHOFF";
			try 
			{
				var response = wb.DownloadString(url);
			}
			catch (Exception x)
			{
				Console.WriteLine ("HTTP ERROR");
			}
		}
		static void redbeacon(bool mode){
			var wb = new WebClient ();
			var url="";
			if(mode)
				url = "http://192.168.1.145/?CH=2&ACTION=SWITCHON";
			else
				url = "http://192.168.1.145/?CH=2&ACTION=SWITCHOFF";
			try 
			{
				var response = wb.DownloadString(url);
			}
			catch (Exception x)
			{
				Console.WriteLine ("HTTP ERROR");
			}
		}
		static void greenbeacon(bool mode){
			var wb = new WebClient ();
			var url="";
			if(mode)
				url = "http://192.168.1.145/?CH=3&ACTION=SWITCHON";
			else
				url = "http://192.168.1.145/?CH=3&ACTION=SWITCHOFF";
			try 
			{
				var response = wb.DownloadString(url);
			}
			catch (Exception x)
			{
				Console.WriteLine ("HTTP ERROR");
			}
		}


	}
}