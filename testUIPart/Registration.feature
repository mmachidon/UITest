Feature: Registration User test

Scenario Outline: Registration check
    Given I am a User
    When I submit a email to Registration Form
	And submit all required fields
    Then I can login to aplication