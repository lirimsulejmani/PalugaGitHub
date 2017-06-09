/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
gp_clean = require('gulp-clean')

var paths = {
    webroot: "./wwwroot/"
};

paths.npmSrc = "./node_modules";
paths.npmLibs = paths.webroot + "lib/npmlibs/";

gulp.task("copy-deps:systemjs", function () {
    return gulp.src(paths.npmSrc + '/systemjs/dist/system.src.js')
        .pipe(gulp.dest(paths.npmLibs + '/systemjs/'));
});

gulp.task("copy-deps:angular2", function () {
    return gulp.src(paths.npmSrc + '/@angular/**')
        .pipe(gulp.dest(paths.npmLibs + '/@angular/'));
});

gulp.task("copy-deps:core-js", function () {
    return gulp.src(paths.npmSrc + '/core-js/client/shim.min.js')
        .pipe(gulp.dest(paths.npmLibs + '/core-js/'));
});

gulp.task("copy-deps:rxjs", function () {
    return gulp.src(paths.npmSrc + '/rxjs/**')
        .pipe(gulp.dest(paths.npmLibs + '/rxjs/'));
});

gulp.task("copy-deps:zone-js", function () {
    return gulp.src(paths.npmSrc + '/zone.js/dist/*')
        .pipe(gulp.dest(paths.npmLibs + '/zone.js/'));
});

gulp.task("copy-deps:angular-in-memory-web-api", function () {
    return gulp.src(paths.npmSrc + '/angular-in-memory-web-api/**/*', { base: paths.npmSrc + '/angular-in-memory-web-api/' })
        .pipe(gulp.dest(paths.npmLibs + '/angular-in-memory-web-api/'));
});

gulp.task("copy-deps:ng2-imageupload", function () {
    return gulp.src(paths.npmSrc + '/ng2-imageupload/**/*', { base: paths.npmSrc + '/ng2-imageupload/' })
        .pipe(gulp.dest(paths.npmLibs + '/ng2-imageupload/'));
});

gulp.task('clean', function () {
    return gulp.src(paths.npmLibs, { read: false })
    .pipe(gp_clean({ force: true }));
});

gulp.task("copy-deps", [
    "copy-deps:rxjs",
    'copy-deps:angular2',
    'copy-deps:systemjs',
    'copy-deps:core-js',
    'copy-deps:zone-js',
    'copy-deps:angular-in-memory-web-api',
    'copy-deps:ng2-imageupload'
]);

///// <binding Clean='default' />
//var gulp = require('gulp'),
//    gp_clean = require('gulp-clean'),
//    gp_concat = require('gulp-concat'),
//    gp_sourcemaps = require('gulp-sourcemaps'),
//    gp_typescript = require('gulp-typescript'),
//    gp_uglify = require('gulp-uglify');

///// Define paths
//var srcPaths = {
//    main: [],
//    app: ['Scripts/app/**/*.ts'],
//    views: ['Scripts/app/**/*.html'],
//    js: [
//        'Scripts/js/**/*.js',
//        'node_modules/core-js/client/shim.min.js',
//        'node_modules/zone.js/dist/zone.js',
//        'node_modules/reflect-metadata/Reflect.js',
//        'node_modules/systemjs/dist/system.src.js',
//        'node_modules/typescript/lib/typescript.js'
//    ],
//    js_angular: [
//        'node_modules/@angular/**'
//    ],
//    js_rxjs: [
//        'node_modules/rxjs/**'
//    ]
//};

//var destPaths = {
//    app: 'wwwroot/app/',
//    js: 'wwwroot/js/',
//    js_angular: 'wwwroot/js/@angular/',
//    js_rxjs: 'wwwroot/js/rxjs/'
//};

//// Compile, minify and create sourcemaps all TypeScript files and place them to wwwroot/app, together with their js.map files.
//gulp.task('app', ['app_clean'], function () {
//    return gulp.src(srcPaths.app)
//        //.pipe(gp_sourcemaps.init())
//        .pipe(gp_typescript(require('./tsconfig.json').compilerOptions))
//        //.pipe(gp_uglify({ mangle: false }))
//		//.pipe(gp_sourcemaps.write('/'))
//        .pipe(gulp.dest(destPaths.app));
//});

//// Delete wwwroot/app contents
//gulp.task('app_clean', function () {
//    return gulp.src(destPaths.app + "*.*", { read: false })
//    .pipe(gp_clean({ force: true }));
//});

//// Copy all JS files from external libraries to wwwroot/js
//gulp.task('js', function () {
//    gulp.src(srcPaths.js_angular)
//        .pipe(gulp.dest(destPaths.js_angular));
//    gulp.src(srcPaths.js_rxjs)
//        .pipe(gulp.dest(destPaths.js_rxjs));
//    return gulp.src(srcPaths.js)
//        .pipe(gulp.dest(destPaths.js));
//});

//// Copy all html files from external libraries to wwwroot/app
//gulp.task('html', function () {
//    return gulp.src(srcPaths.views)
//        .pipe(gulp.dest(destPaths.app));
//});

//// Delete wwwroot/js contents
//gulp.task('js_clean', function () {
//    return gulp.src(destPaths.js + "*.*", { read: false })
//    .pipe(gp_clean({ force: true }));
//});

//// Watch specified files and define what to do upon file changes
//gulp.task('watch', function () {
//    gulp.watch([srcPaths.app, srcPaths.js], ['app', 'js', 'html']);
//});

//// Global cleanup task
//gulp.task('cleanup', ['app_clean', 'js_clean']);

//// Define the default task so it will launch all other tasks
//gulp.task('default', ['app', 'js', 'html', 'watch']);
