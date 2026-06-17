Feature:Tasks

@checkbox
Scenario: Checkbox Validation
  Given I navigates to "checkbox" page
  When I click on "expand" button
  And I select "Desktop" checkbox
  And I select "Documents" checkbox
  And I select "Downloads" checkbox
  Then I should see "desktop" in "Result" area
  And I should see "documents" in "Result" area
  And I should see "downloads" in "Result" area

  @radiobutton
  Scenario: Radiobutton Validaton
     Given I navigates to "radio" page
     When I select "yes" radio button
     Then "yes" radio button is selected
     And "impressive" radio button is unselected
     And I should see "Yes" in "Text" area
     When I select "impressive" radio button
     Then "impressive" radio button is selected
     And "yes" radio button is unselected
     And I should see "Impressive" in "Text" area
     And "no" radio button is disabled

 @Multitab
 Scenario: Multitab handling
    Given I navigates to "browser" page
    When I click on "newtab" multitab button

@Frames
Scenario: Frame Handling
    Given I navigates to "Frames" page
    Then I should see "This is a sample page" in frame "frame"
    And I should see "This is a sample page" in frame "frame1"
    Given I navigates to "Nestedframes" page
    Then I should see "Parent frame" in Nframe "frame"
     And I should see "Child Iframe" in "childframe" which is in "frame"

@uploadanddwnld
Scenario: Upload and Download
    Given I navigates to "upload" page
    When I upload "C:\Users\Preetham.k\OneDrive - TECHNOVERT SOLUTIONS PRIVATE LIMITED\Documents\installation steps.txt" file in "upload"
    Then I should see "C:\fakepath\installation steps.txt" in "uploadedfilepath" area
    When I download using "download" button
    Then File exists locally
    
@Sortable
Scenario:Drag and Drop
  Given I navigates to "sortable" page
  When I reorder "One" to "Three"
  Then items should be reordered

@Resize
Scenario: Resize
  Given I navigates to "Resize" page
  When I Resize the box
  Then Box should be resized
   

     

 