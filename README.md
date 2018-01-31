# indicatorsaremagic

This tool generate network indicators by performing actions from a host that can be launched by users on a workstation.  The idea is to set up websites in a remote location and then configure indictatorsaremagic to perform DNS requests, HTTP GETS, POSTS, etc.

Current capabilities are: 
HTTP/S Gets
HTTP/S Posts of files
HTTP/S Posts of fields
DNS requests

Users can change fields like user agents and language.  Users can also configure tools to run requests at regular intervals.

Configurations are done in XML and then used in the tools see the samples here:

https://github.com/sealingtech/indicatorsaremagic/blob/master/IndicatorMagic2/Xml
 
This tool can be useful for:
Training of network defenders
Testing of network tools

This was designed to be done in an operational environment.
