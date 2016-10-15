

var mainspacecontroller = tourcityapp.controller('main-space',
    function ($scope, $http) {


        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        
        getBusiness($http);
       
        hideEdit();
       
        $scope.showEdit = function () { showEdit(); }

        $scope.hideEdit = function () { hideEdit(); }

        $scope.SaveWelcome = function()
        {
            var data = $.param({
                value: $scope.businessData.Title,
                propertyName: "Title",
                id: $scope.businessData.Id
            });

            $http.post('/space/UpdateProperty', data, config)
            .success(function (data, status, headers, config) {
                saveWelcome();
            });
        }


        function saveWelcome()
        {
            var data = $.param({
                value: $scope.businessData.Welcome,
                propertyName: "Welcome",
                id: $scope.businessData.Id
            });

            $http.post('/space/UpdateProperty', data, config)
            .success(function (data, status, headers, config) {
               
            });
        }

        function showEdit()
        {
             $('#welcome-display').hide();
            $('#welcome-edit').fadeIn(150);
        }

        function hideEdit()
        {
            $('#welcome-edit').hide();
            $('#welcome-display').fadeIn(150);
        }

        function getBusiness($http) {
            $http.get("/space/getbusiness?id=1").then(function (response)
            {
                $scope.businessData = response.data;
            });
        }

      
    });


