Feature: Blood Pressure Category Calculation
  As a user
  I want to calculate my blood pressure category
  So that I can monitor my health

  Scenario: Calculate category for ideal values
    Given I have entered 110 as the systolic value
    And I have entered 70 as the diastolic value
    When I press Submit
    Then the result should be "Ideal"

  Scenario: Calculate category for low values
    Given I have entered 85 as the systolic value
    And I have entered 59 as the diastolic value
    When I press Submit
    Then the result should be "Low"

  Scenario: Calculate category for invalid values
    Given I have entered 20 as the systolic value
    And I have entered 10 as the diastolic value
    When I press Submit
    Then the result should be "Invalid"