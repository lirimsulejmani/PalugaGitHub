/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var paths = {
    webroot: "./wwwroot/"
};

paths.npmSrc = "./node_modules/";
paths.npmLibs = paths.webroot + "lib/npmlibs/";

gulp.task("copy-deps:systemjs", function () {
    return gulp.src(paths.npmSrc + '/systemjs/**/*', { base: paths.npmSrc + '/systemjs/' })
        .pipe(gulp.dest(paths.npmLibs + '/systemjs/'));
});

gulp.task("copy-deps:angular2", function () {
    return gulp.src(paths.npmSrc + '/@angular/**/*', { base: paths.npmSrc + '/@angular/' })
        .pipe(gulp.dest(paths.npmLibs + '/@angular/'));
});

gulp.task("copy-deps:core-js", function () {
    return gulp.src(paths.npmSrc + '/core-js/**/*', { base: paths.npmSrc + '/core-js/' })
        .pipe(gulp.dest(paths.npmLibs + '/core-js/'));
});

gulp.task("copy-deps:rxjs", function () {
    return gulp.src(paths.npmSrc + '/rxjs/**/*', { base: paths.npmSrc + '/rxjs/' })
        .pipe(gulp.dest(paths.npmLibs + '/rxjs/'));
});

gulp.task("copy-deps:zone-js", function () {
    return gulp.src(paths.npmSrc + '/zone.js/**/*', { base: paths.npmSrc + '/zone.js/' })
        .pipe(gulp.dest(paths.npmLibs + '/zone.js/'));
});

gulp.task("copy-deps:angular-in-memory-web-api", function () {
    return gulp.src(paths.npmSrc + '/angular-in-memory-web-api/**/*', { base: paths.npmSrc + '/angular-in-memory-web-api/' })
        .pipe(gulp.dest(paths.npmLibs + '/angular-in-memory-web-api/'));
});

gulp.task("copy-deps", [
    "copy-deps:rxjs",
    'copy-deps:angular2',
    'copy-deps:systemjs',
    'copy-deps:core-js',
    'copy-deps:zone-js',
    'copy-deps:angular-in-memory-web-api'
]);