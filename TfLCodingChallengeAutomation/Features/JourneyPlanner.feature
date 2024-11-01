Feature: JourneyPlanner

Background:
		Given that TfL website is loaded
		When a user clicks on the Accept all cookies button
		

Scenario: 01_Verify that a valid journey can be planned using the widget
		When a user inputs 'leic' into the From text field  
		And a user clicks on 'Leicester Square Underground Station' from the list suggested for From field
		And a user inputs 'cove' into the To text field 
		And a user clicks on 'Covent Garden Underground station' from the list suggested for To field
		And a user clicks on plan my journey button
		Then a journey result page showing 'Walking and Cycling times' must be displayed

Scenario: 02_On the Journey results page, verify that a journey preferences can be amended by using the “Edit preferences” button.
		When a user inputs 'leic' into the From text field
		And a user clicks on 'Leicester Square Underground Station' from the list suggested for From field
		And a user inputs 'cove' into the To text field
		And a user clicks on 'Covent Garden Underground Station' from the list suggested for To field
		And a user clicks on plan my journey button
		And a user clicks the Edit preferences dropdown button
		And a user clicks the Routes with least walking button
		And a user clicks on the Update journey button
		Then a journey result page showing journey times must be displayed
		 
Scenario: 03_On the Journey results page, verify that a user is able to view complete access information at an Underground Station.
		When a user inputs 'leic' into the From text field
		And a user clicks on 'Leicester Square Underground Station' from the list suggested for From field
		And a user inputs 'cove' into the To text field
		And a user clicks on 'Covent Garden Underground Station' from the list suggested for To field
		And a user clicks on plan my journey button
		And a user clicks the Edit preferences dropdown button
		And a user clicks the Routes with least walking button
		And a user clicks on the Update journey button
		Then a journey result page showing journey times must be displayed
		When a user clicks on 'View details' on a selected journey
		Then a complete access information at the Underground Station should be visible.

Scenario: 04_Verify that the widget is unable to provide results when an invalid journey is planned
		When a user inputs 'leic' into the From text field
		And a user clicks on 'Leicester Square Underground Station' from the list suggested for From field
		And a user inputs the To text field with '1'
		And a user clicks on plan my journey button
		Then the journey results page must display 'Journey planner could not find any results to your search' input

Scenario: 05_Verify that the widget is unable to plan a journey if no locations are entered into the widget
		When a user clicks on plan my journey button
		Then a user must get an error message stating 'The From field is required' and 'The To field is required'

		# Unexecuted Scenarios
Scenario: 06_Verify that the “Recents” tab on the widget displays a list of recently planned journeys.
		Pre-requisite: At least one journey must recently be planned.
		When user inputs 'leic' into the From text field
		And user clicks on 'Leicester Square Underground Station' from the list suggested for From field
		And user inputs 'cove' into the To text field
		And user clicks on 'Covent Garden Underground station' from the list suggested for To field
		And user clicks on plan my journey button
		And user clicks the Home icon
		And user clicks on the Recents link
		Then list of recent journeys must be displayed with 'Turn off / clear' link below the list


Scenario: 07_ Verify journey planner can be used to plan a journey using postcodes
        When user inputs 'SE26 6HF' into the From text field
        And user inputs 'RM10 8QZ' into the To text field
        And user clicks on plan my journey button
        Then a journey results page showing journey details must display
        


Scenario: 08_Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
		When user inputs 'Lew' into the From text field 
		And user clicks on 'Lewisham Rail Station' from the list suggested for From field
		And user inputs 'Cat' into the To text field 
		And user clicks on 'Catford Rail station' from the list suggested for To field
		And a user clicks on Change Time link
		Then a user must see the 'Arriving' option
		When a user clicks on the arriving option button
		And a user selects 'Mon 11 Dec' from the date dropdown
		And a user selects '17:30' from the time dropdown
		And user clicks on plan my journey button
		Then journey result page showing 'Earlier journey' must be displayed

Scenario: 09_On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button.
		When user inputs 'Lew' into the From text field 
		And user clicks on 'Lewisham Rail Station' from the list suggested for From field
		And user inputs 'Cat' into the To text field 
		And user clicks on 'Catford Rail station' from the list suggested for To field
		And user clicks on plan my journey button
		And a user clicks on the Edit journey link
		And a user clicks on the Clear-field icon
		And a user input the To text field with 'Lad'
		And a user clicks on 'Ladywell Rail station' from the list of suggested for edit
		And a user clicks on Update Journey button
		Then a journey result page showing 'Earlier journey' must be loaded