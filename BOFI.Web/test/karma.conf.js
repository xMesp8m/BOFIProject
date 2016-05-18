module.exports = function(config){
  config.set({

    basePath : '../App',


    files: [
        '../test/lib/sinon-1.17.2.js',
      '../Scripts/angular.js',
      '../Scripts/angular-resource.js',
      '../Scripts/angular-route.js',
      '../Scripts/angular-mocks.js',
      //'../test/lib/angular-mocks.js',

      '../App/app.js',
      '../App/js/controllers/bofiController.js',
      '../test/unit/**/*.js'
    ],

    autoWatch : true,

    frameworks: ['jasmine'],

    browsers : ['Chrome'],

    plugins : [
      'karma-chrome-launcher',
      'karma-jasmine',
      'karma-ng-html2js-preprocessor',
      'karma-sinon'
    ],

    junitReporter : {
      outputFile: 'test_out/unit.xml',
      suite: 'unit'
    }

  });
};
