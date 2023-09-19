/*!
 * ASP.NET SignalR JavaScript Library v2.2.2
 * http://signalr.net/
 *
 * Copyright (c) .NET Foundation. All rights reserved.
 * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 *
 */

/// <reference path="..\..\SignalR.Client.JS\Scripts\jquery-1.6.4.js" />
/// <reference path="jquery.signalR.js" />
(function ($, window, undefined) {
    /// <param name="$" type="jQuery" />
    "use strict";

    if (typeof ($.signalR) !== "function") {
        throw new Error("SignalR: SignalR is not loaded. Please ensure jquery.signalR-x.js is referenced before ~/signalr/js.");
    }

    var signalR = $.signalR;

    function makeProxyCallback(hub, callback) {
        return function () {
            // Call the client hub method
            callback.apply(hub, $.makeArray(arguments));
        };
    }

    function registerHubProxies(instance, shouldSubscribe) {
        var key, hub, memberKey, memberValue, subscriptionMethod;

        for (key in instance) {
            if (instance.hasOwnProperty(key)) {
                hub = instance[key];

                if (!(hub.hubName)) {
                    // Not a client hub
                    continue;
                }

                if (shouldSubscribe) {
                    // We want to subscribe to the hub events
                    subscriptionMethod = hub.on;
                } else {
                    // We want to unsubscribe from the hub events
                    subscriptionMethod = hub.off;
                }

                // Loop through all members on the hub and find client hub functions to subscribe/unsubscribe
                for (memberKey in hub.client) {
                    if (hub.client.hasOwnProperty(memberKey)) {
                        memberValue = hub.client[memberKey];

                        if (!$.isFunction(memberValue)) {
                            // Not a client hub function
                            continue;
                        }

                        subscriptionMethod.call(hub, memberKey, makeProxyCallback(hub, memberValue));
                    }
                }
            }
        }
    }

    $.hubConnection.prototype.createHubProxies = function () {
        var proxies = {};
        this.starting(function () {
            // Register the hub proxies as subscribed
            // (instance, shouldSubscribe)
            registerHubProxies(proxies, true);

            this._registerSubscribedHubs();
        }).disconnected(function () {
            // Unsubscribe all hub proxies when we "disconnect".  This is to ensure that we do not re-add functional call backs.
            // (instance, shouldSubscribe)
            registerHubProxies(proxies, false);
        });

        proxies['systemGalaxySignalRHub'] = this.createHubProxy('systemGalaxySignalRHub'); 
        proxies['systemGalaxySignalRHub'].client = { };
        proxies['systemGalaxySignalRHub'].server = {
            joinGroup: function (group) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["JoinGroup"], $.makeArray(arguments)));
             },

            leaveGroup: function (group) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["LeaveGroup"], $.makeArray(arguments)));
             },

            notifyAcknowledgeAlarmEvent: function (acknowledgeEventData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyAcknowledgeAlarmEvent"], $.makeArray(arguments)));
             },

            notifyActivityLogData: function (activityData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyActivityLogData"], $.makeArray(arguments)));
             },

            notifyAlarmEvent: function (activityData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyAlarmEvent"], $.makeArray(arguments)));
             },

            notifyAssaDsrNewEventData: function (eventData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyAssaDsrNewEventData"], $.makeArray(arguments)));
             },

            notifyAssaDsrNotifyUpdatedData: function (eventData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyAssaDsrNotifyUpdatedData"], $.makeArray(arguments)));
             },

            notifyControllerStatusData: function (controllerData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyControllerStatusData"], $.makeArray(arguments)));
             },

            notifyDoorReaderStatusData: function (doorStatusData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyDoorReaderStatusData"], $.makeArray(arguments)));
             },

            notifyGenericAlarmEvent: function (genericAlarmEventData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyGenericAlarmEvent"], $.makeArray(arguments)));
             },

            notifyNotInSystemActivityLogData: function (activityData) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["NotifyNotInSystemActivityLogData"], $.makeArray(arguments)));
             },

            send: function (name, message) {
                return proxies['systemGalaxySignalRHub'].invoke.apply(proxies['systemGalaxySignalRHub'], $.merge(["Send"], $.makeArray(arguments)));
             }
        };

        return proxies;
    };

    signalR.hub = $.hubConnection("/signalr", { useDefaultPath: false });
    $.extend(signalR, signalR.hub.createHubProxies());

}(window.jQuery, window));