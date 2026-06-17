@smoke
Feature: TextBox
  
  @textbox
  Scenario Outline: Fill form details
    Given I navigates to "textbox" page
    When I enter "<name>" as "name"
    When I enter "<email>" as "email"
    And I enter "<currentAddress>" as "current address"
    And I enter "<permanentAddress>" as "permanent address"
    When I click on "submit" button
    Then I should see "<name>" in "outputname"

  Examples:
    | name    | email            | currentAddress | permanentAddress   |
    | Preetham| preetham@test.com| Hyderabad      | Telangana          |
    | Akshay  | Ak47@test.com    | Hyderabad      | Telangana          |

    