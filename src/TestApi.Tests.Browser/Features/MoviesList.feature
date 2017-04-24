Feature: MoviesList
	This is a list that contains my Movies

@mytag
Scenario: Count of movies
	Given my Movies website
	When I navigate to the fetch data page
	Then I am presented with exactly 2 movies