
Project overview:
The charging profile generator creates charging schedules using the given input and returns a result. This way user  gets the lowest energy bill based on tariffs. If he starts charging during off-peak timings, then the user gets the lowest energy bill. If the car's current battery level is lower than the desired charging level, then charge even in peak hours. Once desired charging level is reached, then charges during off-peak hours.



Set up to run:
To install:
Run local with CLI
Clone or download this repository to local machine.
Install .NET Core SDK for your platform if didn't install yet.
dotnet restore
dotnet run


Run on Visual Studio
Install Visual Studio 2022 for your platform if didn't install yet.
It works on Windows, macOS and Linux.
You must have the .NET SDK installed. .NET 6.0 is recommended.
Open project
Debug -> Start debugging


Inputs used and tested 
![image](https://user-images.githubusercontent.com/48356037/164997634-3072119d-0221-49c5-ac02-409f7f9ed7a9.png)

Case 1:
Input
{
	"StartingTime": "2022-04-24T13:14:26Z ",
	"UserSettings": {
		"DesiredStateOfCharge": 100,
		"LeavingTime": "7",
		"DirectChargingPercentage": 20,
		"Tariffs": [
			{
				"StartTime": "0:00",
				"EndTime": "7:00",
				"EnergyPrice": 0.22
			},
			{
				"StartTime": "7:15",
				"EndTime": "22:59",
				"EnergyPrice": 0.25
			},
			{
				"StartTime": "23:00",
				"EndTime": "23:59",
				"EnergyPrice": 0.22
			}
		]
	},
	"CarData": {
		"ChargePower": 9.6,
		"BatteryCapacity": 55.0,
		"CurrentBatteryLevel": 25.0
	}
}

Output
![image](https://user-images.githubusercontent.com/48356037/164997708-a3ca6256-7226-4fef-91df-5bfdadae0df8.png)


Case 2:
{
	"StartingTime": "2022-04-24T13:14:26Z ",
	"UserSettings": {
		"DesiredStateOfCharge": 100,
		"LeavingTime": "7",
		"DirectChargingPercentage": 20,
		"Tariffs": [
			{
				"StartTime": "0:00",
				"EndTime": "7:00",
				"EnergyPrice": 0.22
			},
			{
				"StartTime": "7:15",
				"EndTime": "22:59",
				"EnergyPrice": 0.25
			},
			{
				"StartTime": "23:00",
				"EndTime": "23:59",
				"EnergyPrice": 0.22
			}
		]
	},
	"CarData": {
		"ChargePower": 9.6,
		"BatteryCapacity": 55.0,
		"CurrentBatteryLevel": 5.0
	}
}

Output
![image](https://user-images.githubusercontent.com/48356037/164997776-81583378-306a-4ce4-b68e-15b6857ba4c0.png)


Case 3 :
{
	"StartingTime": "2022-04-24T13:14:26Z ",
	"UserSettings": {
		"DesiredStateOfCharge": 100,
		"LeavingTime": "7",
		"DirectChargingPercentage": 20,
		"Tariffs": [
			{
				"StartTime": "0:00",
				"EndTime": "7:00",
				"EnergyPrice": 0.22
			},
			{
				"StartTime": "7:15",
				"EndTime": "22:59",
				"EnergyPrice": 0.25
			},
			{
				"StartTime": "23:00",
				"EndTime": "23:59",
				"EnergyPrice": 0.22
			}
		]
	},
	"CarData": {
		"ChargePower": 9.6,
		"BatteryCapacity": 55.0,
		"CurrentBatteryLevel": 55.0
	}
}

Output
![image](https://user-images.githubusercontent.com/48356037/164998059-2bb0b011-39ca-49e7-99c0-6c6a7082a992.png)


Attached my calculations
1.![image](https://user-images.githubusercontent.com/48356037/164998148-703744b4-6eaf-4aad-8f85-b5c6c8267da2.png)


2.![image](https://user-images.githubusercontent.com/48356037/164998233-e840b08c-7cf0-44a3-9fff-283b879998a6.png)


3.![image](https://user-images.githubusercontent.com/48356037/164998263-7b0d34e5-1742-47bc-93c3-cc16a2c3acd0.png)







