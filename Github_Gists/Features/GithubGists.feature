Feature: Github Gist Feature

Scenario: Validate Github Gists API Responses
	Given I have request 'body'
	| parameter | value	 |
	| body      | <body> |
	And I have request 'headers'
	| parameter     | value       |
	| Authorization | <authToken> |
	When I 'POST' '/gists/<gist_id>/comments' endpoint
	Then I should get '<statusCode>' Response
	Examples:
	| statusCode | authToken   | body                      | gist_id      | Description                    |
	| 201        |             | Adding a comment for Gist | gist_id      | Successful creation of comment |
	| 401        | invalidAuth | Adding a comment for Gist | gist_id      | Invalid Authorization Token    |
	| 404        |             | Adding a comment for Gist | invalid_gist | Invalid Gist Id                |
	| 422        |             |                           | gist_id      | Invalid/Empty request body     |

	
