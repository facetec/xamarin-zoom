#!/bin/bash

#
# This script generates a universal or 'fat' version of libZoomAuthenticationBridge that 
#  contains all build architecture variants combined.
#

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
PROJECT_DIR="$DIR/BridgeProject/ZoomAuthenticationBridge"
PROJECT_PATH="$PROJECT_DIR/ZoomAuthenticationBridge.xcodeproj"
BUILD_DIR="$PROJECT_DIR/build"

function build_library {
    xcodebuild -project $PROJECT_PATH -target ZoomAuthenticationBridge -configuration Release -sdk $1 -arch $2 clean build &&
    cp "$BUILD_DIR/Release-$1/libZoomAuthenticationBridge.a" "$BUILD_DIR/libZoomAuthenticationBridge-$2.a"
}

build_library iphonesimulator i386 &&
build_library iphonesimulator x86_64 &&
build_library iphoneos arm64 &&
build_library iphoneos armv7 &&

echo "Creating universal binary..." &&

lipo -create -output "./libZoomAuthenticationBridge.a" \
"$BUILD_DIR/libZoomAuthenticationBridge-i386.a" \
"$BUILD_DIR/libZoomAuthenticationBridge-arm64.a" \
"$BUILD_DIR/libZoomAuthenticationBridge-armv7.a" \
"$BUILD_DIR/libZoomAuthenticationBridge-x86_64.a"

