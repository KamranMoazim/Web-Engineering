function printTriangle() {
    console.log("*");
    console.log("**");
    console.log("***");
    console.log("****");
    console.log("*****");
}

function printTriangleWitLoop() {
    for (let i = 1; i <= 5; i++) {
        console.log("*".repeat(i));
    }
}


function printTriangleWitLoopInverse() {
    for (let i = 5; i >= 1; i--) {
        console.log("*".repeat(i));
    }
}