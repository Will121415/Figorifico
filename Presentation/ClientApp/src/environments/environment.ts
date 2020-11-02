// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  firebase: {
    apiKey: 'AIzaSyCbpaUBB4UzAafZ9l674D0aHp8ooTVw0hA',
    authDomain: 'frigorifico-web.firebaseapp.com',
    databaseURL: 'https://frigorifico-web.firebaseio.com',
    projectId: 'frigorifico-web',
    storageBucket: 'frigorifico-web.appspot.com',
    messagingSenderId: '981942406379',
    appId: '1:981942406379:web:5b4b110e387397aa6202ae'
  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
