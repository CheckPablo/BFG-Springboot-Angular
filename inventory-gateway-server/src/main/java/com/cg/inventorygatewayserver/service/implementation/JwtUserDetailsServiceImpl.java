/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-10-29 00:11:34
 * @modify date 2020-10-29 00:11:34
 * @desc User detals service Impl - Find username
 */
package com.cg.inventorygatewayserver.service.implementation;

import java.util.ArrayList;

import com.cg.inventorygatewayserver.entity.User;
import com.cg.inventorygatewayserver.exception.InvalidCredentialException;
import com.cg.inventorygatewayserver.repository.UserRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class JwtUserDetailsServiceImpl implements UserDetailsService {

  @Autowired
  private UserRepository userRepository;

  @Override
  public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
    User user = userRepository
      .findByUsername(username)
      .orElseThrow(() -> new InvalidCredentialException("username", "User " + username + " doesn't exist"));
    return new org.springframework.security.core.userdetails.User(user.getUsername(), user.getPassword(), new ArrayList<>());
  }

}
