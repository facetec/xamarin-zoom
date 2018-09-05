#
# This runs the Sharpie tool (http://xmn.io/sharpie-docs) to generate some bindings from the framework.
# The results can't be used directly but only require some light editing
#
sharpie bind -output ./ -sdk iphoneos11.4 -namespace ZoomAuthenticationHybrid ./ZoomAuthenticationHybrid.framework/Headers/ZoomAuthenticationHybrid-swift.h -scope ./ZoomAuthenticationHybrid.framework/Headers/ &&

#
# Replace 'nint' with 'ulong' in enum types to fix compilation issue
#
sed -i "" "s/ : nint/ : ulong/g" ./StructsAndEnums.cs
