var request = require("request");
var base_url = "http://localhost:15418/";
// describe("Hello World Server", function() {
//     describe("GET /", function() {
//         it("returns status code 200", function(done) {
//             request.get(base_url, function(error, response, body) {
//                 if (response===undefined) {
//                     console.log(response);
//                     expect(400).toBe(200);
//                 } else {
//                 expect(response.statusCode).toBe(200);
//                 }
//                 done();
//             });
//         });
//         it("returns Hello World", function(done) {
//             request.get(base_url, function(error, response, body) {
//               expect(body).toBe("Hello World");
//               done();
//             });
//           });
//     });
// });