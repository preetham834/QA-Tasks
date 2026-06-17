@tables
@tables
Feature: Web Tables - Add Record

  Scenario Outline: Add new user record
    Given I navigates to "tables" page
    When I click on "add" button
    And I add record "<firstname>" "<lastname>" "<email>" "<age>" "<salary>" "<department>"
    And I click on "submit" button
    Then I should see "<firstname>" in table "table"
    When I search "<firstname>" in "search" bar
    And I click on "edit" button
    When I edit record "Preetham" as "firstname"
   And I click on "submit" button
    And I click on "delete" button
     When I search "Preetham" in "search" bar
     Then I should see no result in "table"


  Examples:
    | firstname | lastname | email         | age | salary | department |
    | John      | Doe      | john@test.com | 30  |  50000 | IT         | 
    | Jack      | Doe      | jack@test.com | 30  | 50000  | IT         |

   
