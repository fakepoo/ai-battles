var aiBattlesApp = angular.module('aiBattlesApp', []);

aiBattlesApp.controller('BattlesCtrl', function ($scope) {
    $scope.battles = [
      {
          'Id': '1001',
          'Player1': {
              'Name': 'Bigfoot',
              'Wins': 12
          },
          'Player2': {
              'Name': 'The Hulk',
              'Wins': 7
          }
      },
      {
          'Id': '1002',
          'Player1': {
              'Name': 'The Wolf',
              'Wins': 5
          },
          'Player2': {
              'Name': 'John P.',
              'Wins': 13
          }
      },
      {
          'Id': '1003',
          'Player1': {
              'Name': 'Judge Dread',
              'Wins': 3
          },
          'Player2': {
              'Name': 'Rage Against the Machine',
              'Wins': 1
          }
      }
    ];
});