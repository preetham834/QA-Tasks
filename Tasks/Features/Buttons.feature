@sanity@regression
@buttons
Feature: Buttons

  Scenario: successful button click
    Given I navigates to "buttons" page
    When I click on "dbclick" buttons
    Then I should see "You have done a double click" in "Doubleclick" area
    When I click on "rightclick" buttons
    Then I should see "You have done a right click" in "Rightclick" area
    When I click on "singleclick" buttons
    Then I should see "You have done a dynamic click" in "Singleclick" area




