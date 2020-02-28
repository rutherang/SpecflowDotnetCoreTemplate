@MS @Google
Feature: Google search

Basic search

Scenario: Search specflow
	Given I visit google page
	When I type 'specflow' in search bar
		And I click search
	Then I see 'About' in search results

Scenario: Search gsw
	Given I visit google page
	When I type 'gsw' in search bar
		And I click search
	Then I see 'About' in search results

Scenario: Search fb
	Given I visit google page
	When I type 'facebook' in search bar
		And I click search
	Then I see 'About' in search results