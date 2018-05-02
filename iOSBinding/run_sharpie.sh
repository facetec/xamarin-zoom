#
# This runs the Sharpie tool (http://xmn.io/sharpie-docs) to generate some bindings from the framework.
# The results can't be used directly but only require some light editing
#
sharpie bind -output ./ -sdk iphoneos11.3 -namespace ZoomAuthentication ./ZoomAuthentication.framework/Headers/ZoomAuthentication-swift.h -scope ./ZoomAuthentication.framework/Headers/ &&

#
# Replace 'nint' with 'ulong' in enum types to fix compilation issue
#
sed -i "" "s/ : nint/ : ulong/g" ./StructsAndEnums.cs
