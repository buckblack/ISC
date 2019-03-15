var request = require("request");
var base_url = "http://localhost:15418/api/users/login";
describe("Api login", () => {
    it("should return missing filed (password)",(done)=>{
        var data={
            username:"admin"
        };
        request.post(base_url,{json: true,body: data},(error,respone,body)=>{
            expect(body.errorCode).toBeGreaterThan(0);
            expect(body.message.toLowerCase()).toContain("");
            done();
        })
    });

    it("should return login info",(done)=>{
        var data={
            username:"admin",
            password:"123456"
        };
        request.post(base_url,{json: true,body: data},(error,respone,body)=>{
            expect(body.errorCode).toBe(0);
            expect(body.data).toBeDefined();
            if(body.data) {
                let jsonProperies=Object.keys(body.data).sort();
                let expected=[
                    'userID',
                    'userName',
                    'token'
                ].sort();
                expect(jsonProperies).toEqual(expected);
            }
            done();
        })
    });
});