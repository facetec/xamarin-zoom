#
# This runs the Sharpie tool (http://xmn.io/sharpie-docs) to generate some bindings from the framework.
# The results can't be used directly and require heavy editing, but they're a good basis for generating the type definitions
#
sharpie bind -output ./ -sdk iphoneos11.3 -namespace Zoom ./BridgeProject/ZoomAuthenticationBridge/ZoomAuthenticationBridge/ZoomAuthenticationBridge.h -scope ./ZoomAuthentication.framework/Headers/  -scope ./BridgeProject/
