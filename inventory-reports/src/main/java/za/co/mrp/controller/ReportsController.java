/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-10-30 00:14:03
 * @modify date 2020-10-30 00:14:03
 * @desc Raw Material Management Endpoint
 */
package za.co.mrp.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/reports")
@CrossOrigin(origins = "*")
public class ReportsController {

	// Find a particular order by its ID
	@GetMapping("/pendingOrders")
	public ResponseEntity<String> findPendingOrders(@PathVariable Long id) {
		return ResponseEntity.status(HttpStatus.OK).body(new String("27"));
	}

	// Fetch all the Orders
	@GetMapping("/allOrders")
	public ResponseEntity<String> fetchTotalOrders() {
		return ResponseEntity.status(HttpStatus.OK).body(new String("56"));
	}

	@GetMapping("/cRate")
	public ResponseEntity<String> consumptionRate() {
		return ResponseEntity.status(HttpStatus.OK).body(new String("56"));
	}

}
