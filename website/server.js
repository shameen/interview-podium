const express = require("express");
const path = require("path");

const port = process.env.port || 1337;
const app = new express();

//Step 1: Build create-react-app
//(Ideally we move this to a Pre/Post-build step)
const execSync = require("child_process").execSync;
execSync("npm run build"); //Production build

//Step 2: express
app.use(express.static(path.join(__dirname, "build")));
app.get("/", function (req, res) {
    res.sendFile(path.join(__dirname, "build", "index.html"));
});

app.listen(port, () => {
    console.log(`Website Listening at http://localhost:${port}`);
});