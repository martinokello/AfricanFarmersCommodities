"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.VehicleType = exports.ItemType = exports.AfricanFarmerCommoditiesService = void 0;
var http_1 = require("@angular/common/http");
require("rxjs/add/operator/map");
var AfricanFarmerCommoditiesService = /** @class */ (function () {
    function AfricanFarmerCommoditiesService(httpClient) {
        this.getAllRoles = "/Account/GetAllRoles";
        this.createRoleUrl = "/Account/CreateRole";
        this.deleteRoleUrl = "/Account/DeleteRole";
        this.postRmoveUserFromRole = "/Account/RemoveUserFromRole";
        this.postAddUserToRole = "/Account/AddUserToRole";
        this.createTransportPricingUrl = "/api/Administration/CreateTransportPricing";
        this.updateTransportPricingUrl = "/api/Administration/UpdateTransportPricing";
        this.getTransportPricingById = "/Home/GetTransportPricingById";
        this.postCurrentPaymentUrl = "/Home/MakePayment";
        this.schedulesPricingsUrl = "/Home/GetSchedulesPricing";
        this.dealsPricingsUrl = "/Home/GetDealsPricing";
        this.transportPricingsUrl = "/Home/GetTransportPricing";
        this.laguagePricingUrl = "/Home/GetLaguagePricing";
        this.postOrUpdateLocationUrl = "/api/Administration/PostLocation";
        this.updateLocationUrl = "/api/Administration/UpdateLocation";
        this.postOrUpdateVehicleUrl = "/api/Administration/PostVehicle";
        this.updateVehicleUrl = "/api/Administration/UpdateVehicle";
        this.postOrCreateSchedulesPricingUrl = "/api/Administration/PostSchedulesPricing";
        this.updateSchedulesPricingUrl = "/api/Administration/UpdateSchedulesPricing";
        this.postLoginUrl = "/Account/Login";
        this.getVerifyLoggedInUser = "/Account/VerifyLoggedInUser";
        this.getLogoutUrl = "/Account/Logout";
        this.postRegisterUrl = "/Account/Register";
        this.postForgotPasswordUrl = "/Account/ForgotPassword";
        this.postSendEmail = " /Home/SendEmail";
        this.httpClient = httpClient;
    }
    AfricanFarmerCommoditiesService.SetUserEmail = function (userEmailAddress) {
        AfricanFarmerCommoditiesService.clientEmailAddress = userEmailAddress;
    };
    AfricanFarmerCommoditiesService.prototype.GetAllRoles = function () {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
        var requestUrl = this.getAllRoles;
        var requestOptions = {
            url: requestUrl,
            method: 'GET',
            headers: headers,
            responseType: 'application/json'
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions.headers).map(function (buf) {
            return function (buf) {
                var roles = buf;
                return roles;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.CreateUserRole = function (role) {
        var body = JSON.stringify({ role: role });
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.createRoleUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var createResult = buf;
                return createResult;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.DeleteUserRole = function (role) {
        var body = JSON.stringify({ role: role });
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.deleteRoleUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var createResult = buf;
                return createResult;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.AddUserToRole = function (email, role) {
        var body = JSON.stringify({ email: email, role: role });
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postAddUserToRole,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.SendEmail = function (body) {
        var headers = new http_1.HttpHeaders({ 'Content-Type': 'multipart/form-data' });
        var requestOptions = {
            url: this.postSendEmail,
            method: 'POST',
            headers: headers
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.RemoveUserFromRole = function (email, role) {
        var body = JSON.stringify({ email: email, role: role });
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postRmoveUserFromRole,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.VerifyLoggedInUser = function () {
        var headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        var requestUrl = this.getVerifyLoggedInUser;
        var requestOptions = {
            url: requestUrl,
            method: 'POST',
            headers: headers
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.LoginByPost = function (userDetail) {
        var body = JSON.stringify(userDetail);
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postLoginUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.LogOut = function () {
        return this.httpClient.get(this.getLogoutUrl).map(function (res) {
            console.log('Response received ' + res.json());
            return res.json();
        });
    };
    AfricanFarmerCommoditiesService.prototype.GetRequest = function (url) {
        return this.httpClient.get(url).map(function (res) {
            console.log('Response received ' + res.json());
            return res.json();
        });
    };
    AfricanFarmerCommoditiesService.prototype.GetSchedulesPricingById = function (schedulesPricingId) {
        var headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        var requestUrl = this.schedulesPricingsUrl + "?schedulesPricingId=" + schedulesPricingId;
        var requestOptions = {
            url: requestUrl,
            method: 'GET',
            headers: headers
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.registerByPost = function (userDetail) {
        var body = JSON.stringify(userDetail);
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postRegisterUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.forgotPasswordByPost = function (userDetail) {
        var body = JSON.stringify(userDetail);
        var actionResult;
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postForgotPasswordUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.PostOrUpdateLocation = function (location) {
        var body = JSON.stringify(location);
        var actionResult;
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postOrUpdateLocationUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.UpdateLocation = function (location) {
        var body = JSON.stringify(location);
        var actionResult;
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.updateLocationUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.PostOrUpdateVehicle = function (vehicle) {
        var body = JSON.stringify(vehicle);
        var actionResult;
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.postOrUpdateVehicleUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.prototype.UpdateVehicle = function (vehicle) {
        var body = JSON.stringify(vehicle);
        var actionResult;
        var headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
        var requestOptions = {
            url: this.updateVehicleUrl,
            method: 'POST',
            headers: headers,
            body: body
        };
        return this.httpClient.request(requestOptions.method, requestOptions.url, requestOptions).map(function (buf) {
            return function (buf) {
                var result = buf;
                return result;
            };
        });
    };
    AfricanFarmerCommoditiesService.isLoginPage = false;
    AfricanFarmerCommoditiesService.clientEmailAddress = "";
    AfricanFarmerCommoditiesService.actUserStatus = {
        isUserLoggedIn: false,
        isUserAdministrator: false
    };
    return AfricanFarmerCommoditiesService;
}());
exports.AfricanFarmerCommoditiesService = AfricanFarmerCommoditiesService;
var ItemType;
(function (ItemType) {
    ItemType[ItemType["Laguage"] = 1] = "Laguage";
    ItemType[ItemType["TravelDocuments"] = 3] = "TravelDocuments";
    ItemType[ItemType["MedicalTreatment"] = 4] = "MedicalTreatment";
})(ItemType = exports.ItemType || (exports.ItemType = {}));
var VehicleType;
(function (VehicleType) {
    VehicleType[VehicleType["Car"] = 0] = "Car";
    VehicleType[VehicleType["Taxi"] = 1] = "Taxi";
    VehicleType[VehicleType["MiniBus"] = 2] = "MiniBus";
    VehicleType[VehicleType["PickUpTrack"] = 3] = "PickUpTrack";
    VehicleType[VehicleType["Truck"] = 4] = "Truck";
})(VehicleType = exports.VehicleType || (exports.VehicleType = {}));
;
//# sourceMappingURL=africanFarmerCommoditiesService.js.map