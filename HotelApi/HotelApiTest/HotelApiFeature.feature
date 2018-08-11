Feature: HotelApiFeature
	In order to perform operations on hotel api
	As an api consumer
	I want to get,post and update different hotels.

@mytag
Scenario Outline: User adds hotel in database by providing valid inputs.
	Given User provide valid hotel id '<id>' and '<name>' for hotel.
	And  User has added required details for the hotel.
	When user calls AddHotel api.
	Then Hotel with id '<id>' should be present in the response.

	Examples: 
	| id | name   |
	| 111  | hotel1 |
	| 211  | hotel2 |
	| 311 | hotel3 |


#Scenario Outline: User updates hotel entry in the database by providing valid inputs.
#	Given User  provided id '<id>'of the hotel which he wants to book and '<noOfRoomsToBeBooked>'.
#    When the user calls hotel api
#	Then rooms should be booked in the hotel with provided '<id>'.
#
#	Examples: 
#
#	| id | noOfRoomsToBeBooked |
#	| 1  | 2                   |
#	| 2  | 1                   |
#
