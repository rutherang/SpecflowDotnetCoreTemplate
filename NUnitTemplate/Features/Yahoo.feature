@Yahoo
Feature: Yahoo search

Basic search

Scenario: Search specflow in yahoo
	Given I visit yahoo page
	When I type 'specflow' in yahoo search bar
		And I click yahoo search
	Then I wait for 5 seconds

Scenario: Search gtreasury in yahoo
	Given I visit yahoo page
	When I type 'gtreasury' in yahoo search bar
		And I click yahoo search
	Then I wait for 10 seconds

Scenario: Search narcos in yahoo
	Given I visit yahoo page
	When I type 'narcos' in yahoo search bar
		And I click yahoo search
	Then I wait for 10 seconds