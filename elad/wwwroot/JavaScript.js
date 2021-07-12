
//function adduser() {
//    let User = {
//        Email: document.getElementById("email").value,
//        FirstName: document.getElementById("firstname").value,
//        LastName: document.getElementById("lastname").value,
//        Password: document.getElementById("password").value

//    };



//    const postData = async (url = 'api/Values', data = {User}) => {
//        console.log(data);
//        const response = await fetch(url, {
//            method: 'POST',
//            credentials: 'same-origin',
//            headers: {
//           'Content-Type': 'application/json;charset=utf-8'
//            },
//            // Body data type must match "Content-Type" header        
//            body: JSON.stringify(data),
//        })

//        try {
          
//                alert("!!!המשתמש נרשם בהצלחה");
//                document.getElementById("111").style = "visibility:visible"
//        } catch (error) {
//            alert("!!!המשתמש  נכשל");
//            console.log("error", error);
//        }
//    }
//}


function adduser() {
    let User = {
        Email: document.getElementById("email").value,
        FirstName: document.getElementById("firstname").value,
        LastName: document.getElementById("lastname").value,
        Password: document.getElementById("password").value

    };

    fetch("api/Values", { //תלך לשרת
        method: "Post",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(User),//שיודע רק לקבל גיסון cs ממירים את היוזר לג'יסון כי הוא הולך ל
    }).then(response => {
        if (response.ok) {
            alert("!!!המשתמש נרשם בהצלחה");
            document.getElementById("111").style = "visibility:visible"
        }
        else { response.json().then(error1 => { alert(JSON.stringify(error1.errors)); }) }
    })
}


function showDiv() {
    document.getElementById("ExUser").style.visibility = "visible";
    document.getElementById("newUser").style.visibility = "visible";
}



//function login() {

//    let Email = document.getElementById("em").value;
//    let Pass = document.getElementById("pass").value;

//    let url = "api/Values/" + Email + "/" + Pass;
//    //fetch("api/U?login=" + email + "&password=" + password)// + "&firstName" + Name
//    fetch(url)
//        .then(response.ok)
//        .then(response => response.json())
//        .then(data => {
//            // if (typeof data == 'object') {
//            sessionStorage.setItem('Hiuser', JSON.stringify(data));
//            window.location.href = "h1.html";
//            //windows.locattion.href = "h1.html?Name=" + user.Name;
//            document.getElementById("hellodiv").innerHTML = "Hello: " + data.FirstName;
//            //  alert("החיפוש עבר בהצלחה");
//            //   }
//            //else
//            //alert("לא נמצא משתמש ");
//            //        }).catch (error => { console.log(error+"לא נמצאו נתונים"); });

//        });

function update() {

    document.getElementById("update").style.visibility = "visible";

}


function InThelogin() {
    var a = JSON.parse(sessionStorage.getItem('Hiuser'));
    document.getElementById("div1").innerHTML = " <h1 >Hello: " + a.firstName + "</h1 >";

}
function putuser() {
    let oldUser = JSON.parse(sessionStorage.getItem("Hiuser"));
    let User2 = {
        UserId: oldUser.userId,
        Email: document.getElementById("11").value,
        FirstName: document.getElementById("22").value,
        LastName: document.getElementById("33").value,
        Password: document.getElementById("44").value
    };

    fetch("api/Values/?Id=" + User2.UserId/* oldUser.userId*/, { //תלך לשרת
        method: "Put",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(User2),//שיודע רק לקבל גיסון cs ממירים את היוזר לג'יסון כי הוא הולך ל
    }).then(response => {
        if (response.ok) {
            //return response.json();
            alert("!!!המשתמש התעדכן בהצלחה");

        }
        else alert("קרה תקלה");


    })



    //.then(data => {
    //    console.log(data))}
    //.then(data => { alert("!!!המשתמש נרשם בהצלחה" + data.firstName); })

}



function login() {
    // let user = {
    //Email: document.getElementById("em").value,
    //Pass: document.getElementById("pass").value,
    //    }

    UserId = document.getElementById("id").value;
    password = document.getElementById("pass").value;


    fetch("api/Values/" + UserId + "/" + password)
        // fetch("api/Values/?login=" + user.Email + "&password=" + user.Pass)
        .then(response => {
            if (response.status == 204)
                alert("שם משתמש /סיסמא לא תקין");
            else if (response.ok) {
                return response.json();
            }
            else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {

            sessionStorage.setItem('Hiuser', JSON.stringify(data));
            alert("החיפוש עבר בהצלחה" + data.firstName);
            window.location.href = "h1.html";
            //windows.locattion.href = "h1.html?Name=" + user.Name;
            InThelogin();
            // document.getElementById("hellodiv").innerHTML = "Hello: " + data.firstName;

        });


}