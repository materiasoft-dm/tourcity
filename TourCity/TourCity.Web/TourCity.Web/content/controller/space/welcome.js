

var mainspacecontroller = tourcityapp.controller('main-space',
    function ($scope, $http) {

        updateWelcome($http);





        function getBusiness($http) {
            $http.get("/space/getbusiness?id=1").then(function (response) { $scope.businessData = response.data; });
        }

        function updateWelcome()
        {
            var data = $.param({
                value: "BenBoga",
                propertyName: "Name",
                id:1
            });
        
            var config = {
                headers : {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http.post('/space/UpdateProperty', data, config)
            .success(function (data, status, headers, config) {
                $scope.PostDataResponse = data;
            })
            .error(function (data, status, header, config) {
                debugger;
            });
        }
    });


