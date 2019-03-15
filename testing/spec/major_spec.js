var request = require("request");
var login_url = "http://localhost:15418/api/users/login";
var base_url = "http://localhost:15418/api/majors";
describe("Api major", () => {
    var loginData = {
        username: "admin",
        password: "123456"
    };
    describe("/ GET ALL", () => {
        it("should return 401", (done) => {
            request.get(base_url, (error, respone, body) => {
                expect(respone.statusCode).toBe(401)
                done();
            });
        });
        it("should return major list", (done) => {
            //login lấy token
            request.post(login_url, {
                json: true,
                body: loginData
            }, (error, respone, body) => {
                const header = {
                    Authorization: body.data.token
                }
                //lấy major list
                request.get(base_url, {
                    json: true,
                    headers: header
                }, (err1, res1, body1) => {
                    expect(body1.errorCode).toBe(0);
                    expect(body1.data).toBeDefined();
                    expect(Array.isArray(body1.data)).toBeTruthy();
                    if (body1.data.length > 0) {
                        let itemProperties = Object.keys(body1.data[0]).sort();
                        let itemExpect = [
                            'majorID',
                            'name'
                        ].sort();
                        expect(itemProperties).toEqual(itemExpect);
                    }
                    done();
                });

            });
        });
    });
    describe("/ GET", () => {

    });
    describe("/ POST", () => {

    });
    describe("/ PUT", () => {

    });
});