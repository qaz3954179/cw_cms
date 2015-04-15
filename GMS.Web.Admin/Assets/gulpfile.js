var gulp = require('gulp');
var stylus = require('gulp-stylus');
var watch = require('gulp-watch');
var notify = require('gulp-notify');
var plumber = require('gulp-plumber');
var nib = require('nib');

gulp.task('watch', function () {
    watch('./stylus/*.styl', function () {
        gulp.src('./stylus/*.styl')
        .pipe(plumber({ errorHandler: notify.onError('error message: <%= error.message%>') }))
        .pipe(stylus({
            compress: true,
            use: [nib()]
        }))
        .pipe(gulp.dest('./css'))
        .pipe(notify({
            message: '<%= file.relative%> mcompiled successful',
            title: 'minify css'
        }));
    });
});
