package main

import (
	"log"
	"net/http"
)

func main() {

	/*
		Serve static files from the "static" directory.
		When a user accesses the root URL ("/"), the server will look for files in the "static" directory and serve them.
		If the file is not found, it will return a 404 error.
	*/
	fileServer := http.FileServer(http.Dir("./static"))
	http.Handle("/", fileServer)
	http.HandleFunc("/form", formHandler)
	http.HandleFunc("/submit", submitHandler)

	fmt.Println("Starting server on :8080...")
	

	log.Fatal(http.ListenAndServe(":8080", nil))

}
