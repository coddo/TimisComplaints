angular
    .module('timisComplaints')
    .controller('LetterController', function (AuthService, $routeParams, $scope, API, HelperService, $timeout) {
        $scope.letters = [];
        $scope.letter = {
            title: '',
            message: '',
            email: ''
        };

        HelperService.StartLoading('getMe');
        API.getMe({}, function (success) {
            $scope.letter.email = success.email;
            HelperService.StopLoading('getMe');
        }, function (error) {
            HelperService.StopLoading('getMe');
            HelperService.ShowMessage('alert-danger', 'Verificati conexiunea la internet si reincarcati pagina!');
        });

        HelperService.StartLoading('loadLetters');
        API.getAllLetters({}, function (success) {
            $scope.letters = success;
            HelperService.StopLoading('loadLetters');
        }, function (error) {
            HelperService.StopLoading('loadLetters');
            HelperService.ShowMessage('alert-danger', 'Verificati conexiunea la internet si reincarcati pagina!');
        });

        $scope.createLetter = function ($event) {
            HelperService.StartLoading('createLetter');
            API.createLetter($scope.letter, function (success) {
                success.email = $scope.letter.email;
                $scope.letters.push(success);
                $scope.letter.title = '';
                $scope.letter.message = '';
                HelperService.StopLoading('createLetter');
            }, function (error) {
                HelperService.StopLoading('createLetter');
            });
        };

        $scope.removeLetter = function (letter, $event) {
            var index = $scope.letters.indexOf(letter);

            if (index >= 0) {
                HelperService.StartLoading('removeLetter');
                API.removeLetter({ id: letter.id }, function (success) {
                    $scope.letters.splice(index, 1);
                    HelperService.StopLoading('removeLetter');
                }, function (error) {
                    HelperService.StopLoading('removeLetter');
                });
            }
        };
    });
