Feature: TMFeature

As a TurnUp portal admin
I would like to create, edit and delete time and material records
So that I can manage employees' time and meterials sucessfully

Scenario: Create Time and materail record with valid details
	Given I logged into turn up portal successfully
	When I navaigate to Time and Material page
	And I create a new time and material record
	Then The record should be created successfully
