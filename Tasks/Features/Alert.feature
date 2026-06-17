Feature:Alerts

@alert
Scenario:Alert handling
  Given I navigates to "alerts" page
  When I click on alert popping "dialog" button
  And I click on alert popping "confirm" button
  Then I should see "You selected Ok" in "confirmresult" area
  When I click on Prompt "Prompt" button
  Then I should see entered value in prompt area
