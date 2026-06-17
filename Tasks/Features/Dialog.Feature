@dialogs
Feature:Modals

Scenario: user click on dialogs
      Given I navigates to "dialogs" page
      When I click on dialog "smallModal" button
      Then "dialogcontent" should contain text "This is a small modal"
      When I click on "closesmallmodal" button
      And I click on dialog "largeModal" button
      Then "dialogcontent" should contain text "Lorem Ipsum "
